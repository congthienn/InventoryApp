import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Select2OptionData } from 'ng-select2';
import { BranchService } from 'src/app/module/branch/branch.service';
import { ProvinceService } from 'src/app/module/province/province.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { DeliveryCompany } from '../model/delivery-company';
import { DeliveryCompanyService } from '../service/delivery-company.service';

@Component({
  selector: 'app-delivery-company-add',
  templateUrl: './delivery-company-add.component.html',
  styleUrls: ['./delivery-company-add.component.css']
})
export class DeliveryCompanyAddComponent implements OnInit {
  addDeliveryCompanyForm!:FormGroup;
  deliveryCompany:DeliveryCompany;
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
      path: '/don-vi-giao-hang/',
      title: 'Đơn vị giao hàng',
      active: true
    },
    {
      path: '/don-vi-giao-hang/them-moi',
      title: 'Thêm mới',
      active: true
    }
  ]
  constructor(private title: Title,  private provinceService: ProvinceService, 
    private branchService: BranchService,
    private deliveryCompanyService: DeliveryCompanyService,
    private sweetalertService : SweetalertService
  ) {
    this.deliveryCompany = {} as DeliveryCompany;   
  }

  ngOnInit(): void {
    this.title.setTitle("Đơn vị giao hàng");
    this.Title = "Quản lý đơn vị giao hàng";
    this.addDeliveryCompanyForm = new FormGroup({
      name: new FormControl(this.deliveryCompany.name,[
        Validators.required
      ]),
      email: new FormControl(this.deliveryCompany.email,[
        Validators.required,
        Validators.email
      ]),
      phoneNumber: new FormControl(this.deliveryCompany.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      fax: new FormControl(this.deliveryCompany.fax),
      taxCode: new FormControl(this.deliveryCompany.taxCode),
      provinceId: new FormControl(this.deliveryCompany.provinceId, Validators.required),
      districtId: new FormControl(this.deliveryCompany.districtId, Validators.required),
      wardId: new FormControl(this.deliveryCompany.wardId, Validators.required),
      address:new FormControl(this.deliveryCompany.address, Validators.required),
      branchId: new FormControl(this.deliveryCompany.branchId, Validators.required),
    })
    this.getProvinceList();
    this.getBranchList();
  }
  get name() { return this.addDeliveryCompanyForm.get('name'); }
  get email() { return this.addDeliveryCompanyForm.get('email'); }
  get taxCode() { return this.addDeliveryCompanyForm.get('taxCode'); }
  get fax() { return this.addDeliveryCompanyForm.get('fax'); }
  get phoneNumber() { return this.addDeliveryCompanyForm.get('phoneNumber'); }
  get provinceId() { return this.addDeliveryCompanyForm.get('provinceId'); }
  get districtId() { return this.addDeliveryCompanyForm.get('districtId'); }
  get wardId() { return this.addDeliveryCompanyForm.get('wardId'); }
  get address() { return this.addDeliveryCompanyForm.get('address'); }
  get branchId() { return this.addDeliveryCompanyForm.get('branchId'); }
  
  changeProvinceValue(data: any){
    this.addDeliveryCompanyForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }
  changeDistrictValue(data: any){
    this.addDeliveryCompanyForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addDeliveryCompanyForm.patchValue({wardId: data != 'null' ? data : null});
    document.getElementById("ward")?.focus();
  }

  changeBranchValue(data: any){
    if(data != undefined){
      this.addDeliveryCompanyForm.patchValue({branchId: data != 'null' ? data : null});
      document.getElementById("branch")?.focus();
    }
  }
  getProvinceList(){
    this.provinceService.getProvinceList().subscribe(response => { 
        this.provinceList = response;
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
  refreshBranchData(){
    this.getBranchList();
  }
  addDeliveryCompanyData(){
    this.submitData = true;

    this.deliveryCompanyService.addDeliveryCompanyData(this.addDeliveryCompanyForm.value).subscribe(
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
    this.sweetalertService.alertAction("/don-vi-giao-hang","Thêm thông tin đơn vị giao hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
