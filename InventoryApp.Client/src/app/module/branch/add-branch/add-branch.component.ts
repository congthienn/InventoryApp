import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import Swal from 'sweetalert2'
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CompanyService } from '../../general/company.service';
import { ProvinceService } from '../../province/province.service';
import { ObjectCheckPath } from '../../share/objectCheckPath';
import { BranchService } from '../branch.service';
import { Branch } from '../model/branch';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';

@Component({
  selector: 'app-add-branch',
  templateUrl: './add-branch.component.html',
  styleUrls: ['./add-branch.component.css']
})
export class AddBranchComponent implements OnInit {
  public Title = '';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/chi-nhanh/',
      title: 'Chi nhánh',
      active: false
    },
    {
      path: '/chi-nhanh/them-moi',
      title: 'Thêm mới',
      active: true
    },
  ]
  public _mainBranchAlreadyExists = false;
  public submitData = false;
  public select2_province!:string;
  public exampleData!: Array<Select2OptionData>;
  addBranchForm!:FormGroup;
  branch:Branch;
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;

  constructor(public title: Title, 
      private provinceService: ProvinceService, 
      private branchService: BranchService,
      private companyService: CompanyService,
      private router: Router,
      private sweetalertService: SweetalertService
    ) 
  { 
    this.branch = {} as Branch;   
  }
  ngOnInit(): void {
    this.title.setTitle("Chi nhánh");
    this.Title = "Quản lý chi nhánh";
    this.addBranchForm = new FormGroup({
      companyName: new FormControl(this.branch.companyName,[
        Validators.required
      ]),
      email: new FormControl(this.branch.email,[
        Validators.required,
        Validators.email
      ]),
      phoneNumber: new FormControl(this.branch.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      fax: new FormControl(this.branch.fax, Validators.required),
      taxCode: new FormControl(this.branch.taxCode, Validators.required),
      provinceId: new FormControl(this.branch.provinceId, Validators.required),
      districtId: new FormControl(this.branch.districtId, Validators.required),
      wardId: new FormControl(this.branch.wardId, Validators.required),
      address:new FormControl(this.branch.address, Validators.required),
      branchMain: new FormControl(this.branch.branchMain),
      companiesId: new FormControl(this.branch.companiesId)
    })
    
    this.companyService.getCompanyInfomation().subscribe(response => {
      this.addBranchForm.patchValue({companiesId: response.id});
    })
   
    this.getProvinceList();
    this.mainBranchAlreadyExists();
  }
  mainBranchAlreadyExists(){
    this.branchService.checkMainBranch().subscribe(
      response => {
        this._mainBranchAlreadyExists = response;
      },
      error => {
        this._mainBranchAlreadyExists = false;
      }
    )
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/chi-nhanh","Thêm thông tin chi nhánh thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  get companyName() { return this.addBranchForm.get('companyName'); }
  get email() { return this.addBranchForm.get('email'); }
  get taxCode() { return this.addBranchForm.get('taxCode'); }
  get fax() { return this.addBranchForm.get('fax'); }
  get phoneNumber() { return this.addBranchForm.get('phoneNumber'); }
  get provinceId() { return this.addBranchForm.get('provinceId'); }
  get districtId() { return this.addBranchForm.get('districtId'); }
  get wardId() { return this.addBranchForm.get('wardId'); }
  get address() { return this.addBranchForm.get('address'); }
  get branchMain() { return this.addBranchForm.get('branchMain'); }
  
  changeProvinceValue(data: any){
    this.addBranchForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }
  changeDistrictValue(data: any){
    this.addBranchForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addBranchForm.patchValue({wardId: data != 'null' ? data : null});
    document.getElementById("ward")?.focus();
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
  addBranch(){
    this.submitData = true;
    if(this._mainBranchAlreadyExists){
      this.addBranchForm.patchValue({branchMain: false})
    }
    this.branchService.addBranch(this.addBranchForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    )
  }
}