import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Select2OptionData } from 'ng-select2';
import { BranchService } from 'src/app/module/branch/branch.service';
import { ProvinceService } from 'src/app/module/province/province.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CustomerGroupComponent } from '../customer-group/customer-group.component';
import { CustomerService } from '../service/customer.service';
import { Customer } from '../model/customer';
import { CustomerGroupService } from '../service/customer-group.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})

export class AddCustomerComponent implements OnInit {
  addCustomerForm!:FormGroup;
  customer:Customer;
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;
  customerGroupList!: Array<Select2OptionData>;
  branchList!: Array<Select2OptionData>;
  submitData = false;
  public Title = '';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/khach-hang/',
      title: 'Khách hàng',
      active: true
    },
    {
      path: '/khach-hang/them-moi',
      title: 'Thêm mới',
      active: true
    }
  ]
  constructor(private title: Title,  private provinceService: ProvinceService, 
    private modalService: NgbModal,
    private customerGroupService: CustomerGroupService,
    private branchService: BranchService,
    private customerService: CustomerService,
    private sweetalertService : SweetalertService
  ) {
    this.customer = {} as Customer;   
  }

  ngOnInit(): void {
    this.title.setTitle("Khách hàng");
    this.Title = "Quản lý khách hàng";
    this.addCustomerForm = new FormGroup({
      customerName: new FormControl(this.customer.customerName,[
        Validators.required
      ]),
      email: new FormControl(this.customer.email,[
        Validators.required,
        Validators.email
      ]),
      phoneNumber: new FormControl(this.customer.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      fax: new FormControl(this.customer.fax),
      taxCode: new FormControl(this.customer.taxCode),
      provinceId: new FormControl(this.customer.provinceId, Validators.required),
      districtId: new FormControl(this.customer.districtId, Validators.required),
      wardId: new FormControl(this.customer.wardId, Validators.required),
      address:new FormControl(this.customer.address, Validators.required),
      customerGroupId: new FormControl(this.customer.customerGroupId, Validators.required),
      branchId: new FormControl(this.customer.branchId, Validators.required),
    })
    this.getProvinceList();
    this.getCustomerGroupList();
    this.getBranchList();
  }
  get customerName() { return this.addCustomerForm.get('customerName'); }
  get email() { return this.addCustomerForm.get('email'); }
  get taxCode() { return this.addCustomerForm.get('taxCode'); }
  get fax() { return this.addCustomerForm.get('fax'); }
  get phoneNumber() { return this.addCustomerForm.get('phoneNumber'); }
  get provinceId() { return this.addCustomerForm.get('provinceId'); }
  get districtId() { return this.addCustomerForm.get('districtId'); }
  get wardId() { return this.addCustomerForm.get('wardId'); }
  get address() { return this.addCustomerForm.get('address'); }
  get customerGroupId() { return this.addCustomerForm.get('customerGroupId'); }
  get branchId() { return this.addCustomerForm.get('branchId'); }
  
  changeProvinceValue(data: any){
    this.addCustomerForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }
  changeDistrictValue(data: any){
    this.addCustomerForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addCustomerForm.patchValue({wardId: data != 'null' ? data : null});
    document.getElementById("ward")?.focus();
  }
  changeCustomerGroupValue(data: any){
    if(data != undefined){
      this.addCustomerForm.patchValue({customerGroupId: data != 'null' ? data : null});
      document.getElementById("customerGroup")?.focus();
    }
  }
  changeBranchValue(data: any){
    if(data != undefined){
      this.addCustomerForm.patchValue({branchId: data != 'null' ? data : null});
      document.getElementById("branch")?.focus();
    }
  }
  getProvinceList(){
    this.provinceService.getProvinceList().subscribe(response => { 
        this.provinceList = response;
    })
  }

  getCustomerGroupList(){ 
    var tempData: { id: string; text: string; }[] = [];
    this.customerGroupService.getAllCustomerGroup().subscribe(response => {
      response.forEach((element: any) => {
          var data = {
            id: element.id,
            text: element.name
          }
          tempData.push(data);
      });
      this.customerGroupList = tempData;
    })
  }
  getBranchList(){
    var tempData: { id: string; text: string; }[] = [];
    this.branchService.getAllBranch().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.companyName
        }
        tempData.push(data);
      });
      this.branchList = tempData;
    })
  }
  getDistrictList(provinceId:string){
    if(provinceId !=  undefined){
      this.provinceService.getDistrictList(provinceId).subscribe(response => {
        this.districtList = response;
      })
    }
  }
  getWardtList(districtId:string){
    this.provinceService.getWardList(districtId).subscribe(response => {
        this.wardList = response;
    })
  }
  open() {	
    this.modalService.open(CustomerGroupComponent).result.then((result) => {
      this.getCustomerGroupList();
      },(reason) => {
        this.getCustomerGroupList();
      });
	}
  refreshData(){
    this.getCustomerGroupList();
  }
  refreshBranchData(){
    this.getBranchList();
  }
  addCustomerData(){
    this.submitData = true;

    this.customerService.addCustomerData(this.addCustomerForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    )
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/khach-hang","Thêm thông tin khách hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
