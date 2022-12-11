import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { AuthService } from 'src/app/auth/auth.service';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CategoryMaterialComponent } from '../category-material.component';
import { CategoryMaterialService } from '../service/category-material.service';

@Component({
  selector: 'app-action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.css']
})
export class ActionButtonComponent implements ICellRendererAngularComp {
  private params: any;
  clickDelete = false;
  constructor(private sweetalertService: SweetalertService, 
    private categoryMaterialService: CategoryMaterialService,
    private modalService: NgbModal,
    private authService: AuthService
  ) { }
  enableButton = this.authService.getRole() === "Quản trị hệ thống";
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
        this.deleteCategoryMaterial(this.params.value)
      }
    })
  }

  deleteCategoryMaterial(id:string){
    this.categoryMaterialService.deleteData(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.modalService.dismissAll();
          this.modalService.open(CategoryMaterialComponent);
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
