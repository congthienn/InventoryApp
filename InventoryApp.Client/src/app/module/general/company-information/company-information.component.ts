import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { ProvinceService } from '../../province/province.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CompanyService } from '../company.service';
import { Company } from '../model/company';

@Component({
  selector: 'app-company-information',
  templateUrl: './company-information.component.html',
  styleUrls: ['./company-information.component.css']
})
export class CompanyInformationComponent implements OnInit {
  public Title = '';
  public hiddenButton = true;
  public company!: Company;
  public provinceIdValue = '';
  public districtIdValue = '';
  public wardIdValue = '';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/cai-dat-chung/',
      title: 'Cài đặt chung',
      active: false
    },
    {
      path: '/cai-dat-chung/thong-tin-cong-ty',
      title: 'Thông tin công ty ',
      active: true
    },
  ]
  public submitData = false;
  public select2_province!:string;
  public exampleData!: Array<Select2OptionData>;
  addCompanyInformationForm!:FormGroup;
  companyInformation:Company;
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;

  constructor(public title: Title, 
      private provinceService: ProvinceService, 
      private companyService: CompanyService,
      private router: Router,
      private sweetalertService: SweetalertService
    ) 
  { 
    this.companyInformation = {} as Company;   
  }

  clickUpdate(){
    this.addCompanyInformationForm.enable();
    this.hiddenButton = false;
  }
  clickCancel(){
    this.getCompanyInformation();
    this.addCompanyInformationForm.disable();
    this.hiddenButton = true;
  }

  ngOnInit(): void {
   
    this.title.setTitle("Thông tin công ty");
    this.Title = "Thông tin công ty";
    this.addCompanyInformationForm = new FormGroup({
      id:new FormControl(this.companyInformation.id, Validators.required),
      companyName: new FormControl(this.companyInformation.companyName,[
        Validators.required
      ]),
      email: new FormControl(this.companyInformation.email,[
        Validators.required,
        Validators.email
      ]),
      phoneNumber: new FormControl(this.companyInformation.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      fax: new FormControl(this.companyInformation.fax, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
      taxCode: new FormControl(this.companyInformation.taxCode, Validators.required),
      provinceId: new FormControl(this.companyInformation.provinceId, Validators.required),
      districtId: new FormControl(this.companyInformation.districtId, Validators.required),
      wardId: new FormControl(this.companyInformation.wardId, Validators.required),
      address:new FormControl(this.companyInformation.address, Validators.required),
    });

    this.addCompanyInformationForm.disable();
    this.getCompanyInformation();
    
  }
  getCompanyInformation(){
    this.companyService.getCompanyInfomation().subscribe(response => {
      this.company = response;
      this.addCompanyInformationForm.patchValue({companyName: this.company.companyName});
      this.addCompanyInformationForm.patchValue({email: this.company.email});
      this.addCompanyInformationForm.patchValue({fax: this.company.fax});
      this.addCompanyInformationForm.patchValue({phoneNumber: this.company.phoneNumber});
      this.addCompanyInformationForm.patchValue({taxCode: this.company.taxCode});
      this.addCompanyInformationForm.patchValue({address: this.company.address});
      this.addCompanyInformationForm.patchValue({id: this.company.id});
      this.addCompanyInformationForm.patchValue({provinceId: this.company.provinceId});
      this.addCompanyInformationForm.patchValue({districtId: this.company.districtId});
      this.addCompanyInformationForm.patchValue({wardId: this.company.wardId});
      this.getProvinceList();
      this.getDistrictList(this.company.provinceId)
      this.getWardtList(this.company.districtId);
      this.provinceIdValue = this.company.provinceId;
      this.districtIdValue = this.company.districtId;
      this.wardIdValue = this.company.wardId;
    })
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/cai-dat-chung/thong-tin-cong-ty","Cập nhật thông tin công thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  get companyName() { return this.addCompanyInformationForm.get('companyName'); }
  get email() { return this.addCompanyInformationForm.get('email'); }
  get taxCode() { return this.addCompanyInformationForm.get('taxCode'); }
  get fax() { return this.addCompanyInformationForm.get('fax'); }
  get phoneNumber() { return this.addCompanyInformationForm.get('phoneNumber'); }
  get provinceId() { return this.addCompanyInformationForm.get('provinceId'); }
  get districtId() { return this.addCompanyInformationForm.get('districtId'); }
  get wardId() { return this.addCompanyInformationForm.get('wardId'); }
  get address() { return this.addCompanyInformationForm.get('address'); }
  
  changeProvinceValue(data: any){
    
    if(Number(data) == Number(this.company.provinceId))
        return;
    this.company.provinceId = "undefined";
    this.provinceIdValue = data;
    this.getDistrictList(data);
    this.wardList = [];
    this.addCompanyInformationForm.patchValue({provinceId: data});
    this.addCompanyInformationForm.patchValue({districtId: null});
    this.addCompanyInformationForm.patchValue({wardId: null});

  }

  changeDistrictValue(data: any){
    if(Number(data) == Number(this.company.districtId))
      return;
    this.company.districtId = "undefined";
    this.districtIdValue = data;
    this.getWardtList(data);
    this.addCompanyInformationForm.patchValue({districtId: data});
    this.addCompanyInformationForm.patchValue({wardId: null});
   
  } 

  changeWardValue(data: any){
    if(Number(data) == Number(this.company.wardId))
      return;
    this.company.wardId = "undefined";
    this.wardIdValue = data;
    this.addCompanyInformationForm.patchValue({wardId: data});
  }
  getProvinceList(){
    this.provinceService.getProvinceList().subscribe(response => { 
        this.provinceList = response; 
    })
  }
  getDistrictList(provinceId:string){
    this.provinceService.getDistrictList(provinceId).subscribe(response => {
        this.districtList = response;
    
    })
  }
  getWardtList(districtId:string){
    this.provinceService.getWardList(districtId).subscribe(response => {
        this.wardList = response;
    })
  }
  addCompanyInformation(){
    this.submitData = true;
    this.companyService.updateCompanyInfomation(this.addCompanyInformationForm.value).subscribe(
      response => {
        this.submitData = false;
        this.showSuccess();
        this.clickCancel();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    )
  }
}