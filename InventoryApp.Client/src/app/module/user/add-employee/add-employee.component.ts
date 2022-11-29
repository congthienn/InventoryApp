import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { ProvinceService } from '../../province/province.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  public Title = '';
  files: File[] = [];
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/nhan-vien/',
      title: 'Nhân viên',
      active: false
    },
    {
      path: '/nhan-vien/them-moi',
      title: 'Thêm mới',
      active: true
    },
  ]
  public submitData = false;
  public select2_province!:string;
  addEmployeeForm!:FormGroup;
  employee:Employee;
  branchList!: Array<Select2OptionData>;
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;

  constructor(public title: Title, 
      private provinceService: ProvinceService, 
      private branchService: BranchService,
      private employeeService: EmployeeService,
      private router: Router,
      private sweetalertService: SweetalertService
    ) 
  { 
    this.employee = {} as Employee;   
  }
  onSelect(event: { addedFiles: any; }) {
		this.files = event.addedFiles;
    this.addEmployeeForm.patchValue({cardImage: this.files[0].name});
    console.log(this.addEmployeeForm);
	}

	onRemove(event: File) {
		this.files.splice(this.files.indexOf(event), 1);
    this.addEmployeeForm.patchValue({cardImage: null});
	}
  ngOnInit(): void {
    this.title.setTitle("Nhân viên");
    this.Title = "Quản lý thông tin nhân viên";
    this.addEmployeeForm = new FormGroup({
      name: new FormControl(this.employee.name, Validators.required),
      sex: new FormControl(this.employee.sex, Validators.required),
      birthday: new FormControl(this.employee.birthday, Validators.required),
      branchId: new FormControl(this.employee.branchId, Validators.required),
      cardImage: new FormControl(this.employee.cardImage, Validators.required),
      identityCard: new FormControl(this.employee.identityCard, [Validators.required, Validators.pattern("^[0-9]*$")]),
      email: new FormControl(this.employee.email, [Validators.required, Validators.email]),
      phoneNumber: new FormControl(this.employee.phoneNumber, [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]*$")]),
      districtId: new FormControl(this.employee.districtId, Validators.required),
      provinceId: new FormControl(this.employee.provinceId, Validators.required),
      wardId: new FormControl(this.employee.wardId, Validators.required),
      address:new FormControl(this.employee.address, Validators.required),
    })

    this.getProvinceList();
    this.getBranchList();
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/nhan-vien","Thêm thông tin nhân viên thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  get name() { return this.addEmployeeForm.get('name'); }
  get sex() { return this.addEmployeeForm.get('sex'); }
  get birthday() { return this.addEmployeeForm.get('birthday'); }
  get branchId() { return this.addEmployeeForm.get('branchId'); }
  get cardImage() { return this.addEmployeeForm.get('cardImage'); }
  get identityCard() { return this.addEmployeeForm.get('identityCard'); }
  get email() { return this.addEmployeeForm.get('email'); }
  get phoneNumber() { return this.addEmployeeForm.get('phoneNumber'); }
  get provinceId() { return this.addEmployeeForm.get('provinceId'); }
  get districtId() { return this.addEmployeeForm.get('districtId'); }
  get wardId() { return this.addEmployeeForm.get('wardId'); }
  get address() { return this.addEmployeeForm.get('address'); }
 
  
  changeProvinceValue(data: any){
    if(data == undefined)
      return;
    this.addEmployeeForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }

  changeBranchValue(branchId:any){
    this.addEmployeeForm.patchValue({branchId: branchId != 'null' ? branchId : null});
  }
  changeDistrictValue(data: any){
    this.addEmployeeForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addEmployeeForm.patchValue({wardId: data != 'null' ? data : null});
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
  
  addEmployee(){
    this.submitData = true;
    var formData = new FormData();
    formData.append("Name", this.addEmployeeForm.get('name')?.value);
    formData.append("Sex", this.addEmployeeForm.get('sex')?.value);
    formData.append("Birthday", this.addEmployeeForm.get('birthday')?.value);
    formData.append("BranchId", this.addEmployeeForm.get('branchId')?.value);
    formData.append("IdentityCard", this.addEmployeeForm.get('identityCard')?.value);
    formData.append("Email", this.addEmployeeForm.get('email')?.value);
    formData.append("PhoneNumber", this.addEmployeeForm.get('phoneNumber')?.value);
    formData.append("ProvinceId", this.addEmployeeForm.get('provinceId')?.value);
    formData.append("DistrictId", this.addEmployeeForm.get('districtId')?.value);
    formData.append("WardId", this.addEmployeeForm.get('wardId')?.value);
    formData.append("Address", this.addEmployeeForm.get('address')?.value);
    formData.append("Image", this.files[0], this.files[0].name);
    this.employeeService.addEmployee(formData).subscribe(
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
