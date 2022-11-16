import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Select2OptionData } from 'ng-select2';
import { BranchService } from 'src/app/module/branch/branch.service';
import { ProvinceService } from 'src/app/module/province/province.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CustomerGroupComponent } from '../../customer/customer-group/customer-group.component';
import { CustomerService } from '../../customer/service/customer.service';
import { Customer } from '../../customer/model/customer';
import { Supplier } from '../model/supplier';
import { SupplierGroupService } from '../service/supplier-group.service';
import { SupplierService } from '../service/supplier.service';
import { SupplierGroupComponent } from '../supplier-group/supplier-group.component';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {
  addSupplierForm!:FormGroup;
  supplier:Supplier;
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;
  supplierGroupList!: Array<Select2OptionData>;
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
      path: '/nha-cung-cap/',
      title: 'Nhà cung cấp',
      active: false
    },
    {
      path: '/them-moi/',
      title: 'Thêm mới',
      active: true
    }
  ]
  constructor(private title: Title,  private provinceService: ProvinceService, 
    private modalService: NgbModal,
    private supplierGroupService: SupplierGroupService,
    private supplierService: SupplierService,
    private sweetalertService : SweetalertService
  ) {
    this.supplier = {} as Supplier;   
  }

  ngOnInit(): void {
    this.title.setTitle("Nhà cung cấp");
    this.Title = "Quản lý nhà cung cấp";
    this.addSupplierForm = new FormGroup({
      supplierName: new FormControl(this.supplier.supplierName,[
        Validators.required
      ]),
      email: new FormControl(this.supplier.email,[
        Validators.required,
        Validators.email
      ]),
      phoneNumber: new FormControl(this.supplier.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      fax: new FormControl(this.supplier.fax),
      taxCode: new FormControl(this.supplier.taxCode),
      provinceId: new FormControl(this.supplier.provinceId, Validators.required),
      districtId: new FormControl(this.supplier.districtId, Validators.required),
      wardId: new FormControl(this.supplier.wardId, Validators.required),
      address:new FormControl(this.supplier.address, Validators.required),
      supplierGroupId: new FormControl(this.supplier.supplierGroupId, Validators.required),
    })
    this.getProvinceList();
    this.getSupplierGroupList();
  }
  get supplierName() { return this.addSupplierForm.get('supplierName'); }
  get email() { return this.addSupplierForm.get('email'); }
  get taxCode() { return this.addSupplierForm.get('taxCode'); }
  get fax() { return this.addSupplierForm.get('fax'); }
  get phoneNumber() { return this.addSupplierForm.get('phoneNumber'); }
  get provinceId() { return this.addSupplierForm.get('provinceId'); }
  get districtId() { return this.addSupplierForm.get('districtId'); }
  get wardId() { return this.addSupplierForm.get('wardId'); }
  get address() { return this.addSupplierForm.get('address'); }
  get supplierGroupId() { return this.addSupplierForm.get('supplierGroupId'); }
  

  changeProvinceValue(data: any){
    this.addSupplierForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }
  changeDistrictValue(data: any){
    this.addSupplierForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addSupplierForm.patchValue({wardId: data != 'null' ? data : null});
    document.getElementById("ward")?.focus();
  }
  changeSupllierGroupValue(data: any){
    if(data != undefined){
      this.addSupplierForm.patchValue({supplierGroupId: data != 'null' ? data : null});
      document.getElementById("supplierGroupId")?.focus();
    }
  }
  getProvinceList(){
    this.provinceService.getProvinceList().subscribe(response => { 
        this.provinceList = response;
    })
  }

  getSupplierGroupList(){ 
    var tempData: { id: string; text: string; }[] = [];
    this.supplierGroupService.getAllSupplierGroups().subscribe(response => {
      response.forEach((element: any) => {
          var data = {
            id: element.id,
            text: element.name
          }
          tempData.push(data);
      });
      this.supplierGroupList = tempData;
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
   this.modalService.open(SupplierGroupComponent)
	}
  refreshData(){
    this.getSupplierGroupList();
  }
  addSupplierData(){
    this.submitData = true;
    this.supplierService.addData(this.addSupplierForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
      }
    )
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/nha-cung-cap","Thêm thông tin nhà cung cấp thành công");
  }
  showError(){
    this.submitData = false;
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}