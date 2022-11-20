import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { CustomerGroupComponent } from 'src/app/module/business-partner/customer/customer-group/customer-group.component';
import { OrderService } from 'src/app/module/order/service/order.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { RoleService } from '../../service/role.service';
import { RoleListComponent } from '../role-list.component';

@Component({
  selector: 'app-action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.css']
})
export class ActionButtonComponent implements ICellRendererAngularComp {
  private params: any;
  clickDelete = false;
  constructor(private sweetalertService: SweetalertService, 
    private roleService: RoleService, 
    private modalService: NgbModal, private roleListComponent : RoleListComponent
  ) { }
  refresh() {
    return false;
  }
  agInit(params: any): void {
    this.params = params;
  }
  btnDelete() {  
    this.clickDelete = true;
    Swal.fire({
      title: 'Bạn muốn xóa dữ liệu?',
      text: "Có thể sẽ ảnh hưởng đến những dữ liệu khác",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Xóa dữ liệu',
      cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
      this.clickDelete = false;
      if (result.isConfirmed) {    
        this.deleteRole(this.params.value)
      }
    })
  }

  deleteRole(id:string){
    this.roleService.deleteRole(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.roleListComponent.getAllRole();
        })
      },
      error => {
        this.sweetalertService.alertMini("Không thể xóa dữ liệu", "Vui lòng kiểm tra lại dữ liệu!", 'error');
      }
    )
  }
  btnUpdate(){
    console.log(this.params.value);
  } 

}
