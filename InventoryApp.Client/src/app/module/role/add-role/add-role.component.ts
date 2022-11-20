import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { CategoryMaterialComponent } from '../../category-material/category-material.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { AddUserComponent } from '../../user/add-user/add-user.component';
import { Role } from '../model/role';
import { RoleListComponent } from '../role-list/role-list.component';
import { RoleService } from '../service/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.css']
})
export class AddRoleComponent implements OnInit {
  submitData = false;
  addRoleForm!:FormGroup;
  role: Role;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private roleService: RoleService,
    private modalService: NgbModal, 

    ) {
    this.role = {} as Role;   
  }
  ngOnInit(): void {
    this.addRoleForm = new FormGroup({
      name: new FormControl(this.role.name, Validators.required)
    })
  }
  get name() { return this.addRoleForm.get('name'); }

  addRole(){
    this.submitData = true;
    this.roleService.addRole(this.addRoleForm.value).subscribe(
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
      text: 'Thêm mới thương hiệu sản phẩm thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.modalService.dismissAll();
      this.modalService.open(AddUserComponent);
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }

}
