import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Select2OptionData } from 'ng-select2';
import { Options } from 'select2';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { RoleListComponent } from '../../role/role-list/role-list.component';
import { RoleService } from '../../role/service/role.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Warehouse } from '../../warehouse/model/warehouse';
import { WarehouseService } from '../../warehouse/service/warehouse.service';
import { User } from '../model/user';
import { UserService } from '../service/user.service';
import { UserListComponent } from '../user-list/user-list.component';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  branchList!: Array<Select2OptionData>;
  roleList!: Array<Select2OptionData>;
  submitData = false;
  addUserForm!:FormGroup;
  user:User;
  options = {
    multiple: true
  };
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private branchService: BranchService,
    private roleService: RoleService,
    private userService : UserService,
    private router : Router,
    private modalService: NgbModal,
    private userListComponent : UserListComponent
    ) {
    this.user = {} as User;   
  }
  ngOnInit(): void {
    this.addUserForm = new FormGroup({
      userName: new FormControl(this.user.userName, Validators.required),
      email: new FormControl(this.user.email,[Validators.required, Validators.email]),
      phoneNumber: new FormControl(this.user.phoneNumber,[
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      branchId: new FormControl(this.user.branchId,[Validators.required]),
      roleId: new FormControl(this.user.roleId, [Validators.required])
    })
    this.getBranchList();
    this.getRoleList();
    
  }
  get userName() { return this.addUserForm.get('userName'); }
  get email() { return this.addUserForm.get('email'); }
  get phoneNumber() { return this.addUserForm.get('phoneNumber'); }
  get branchId() { return this.addUserForm.get('name'); }
  get roleId() { return this.addUserForm.get('roleId'); }
 

  addUser(){
    this.submitData = true;
    this.userService.addUser(this.addUserForm.value).subscribe(
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
    Swal.fire({
      title: 'Success!',
      text: 'Thêm mới tài khoản đăng nhập hệ thống thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.activeModal.close();
      this.userListComponent.getAllUser();
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  refreshBranchData(){
    this.getBranchList();
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
  getRoleList(){
    var tempData: { id: string; text: string; }[] = [];
    this.roleService.getAllRole().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.roleList = tempData;
    })
  }
  changeBranchValue(data: any){
    if(data != undefined){
      this.addUserForm.patchValue({branchId: data != 'null' ? data : null});
      document.getElementById("branchId")?.focus();
    }
  }
  changeRoleValue(data: any){
    if(data != undefined){
      this.addUserForm.patchValue({roleId: data != 'null' ? data : null});
      document.getElementById("roleId")?.focus();
    }
  }
  openModalRoleList(){
    this.modalService.open(RoleListComponent);
  }

}
