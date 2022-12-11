import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { AuthService } from 'src/app/auth/auth.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { MaterialService } from '../../service/material.service';
import { MaterialListComponent } from '../material-list.component';

@Component({
  selector: 'app-action-button-material',
  templateUrl: './action-button-material.component.html',
  styleUrls: ['./action-button-material.component.css']
})
export class ActionButtonMaterialComponent implements ICellRendererAngularComp {
  constructor(private materialService: MaterialService, private sweetalertService: SweetalertService,
    private materialListComponent  : MaterialListComponent,
    private authService: AuthService
    ){}
  enableButton = this.authService.getRole() === "Quản trị hệ thống";
  private params: any;
  public clickDelete = false;
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
        this.deleteMaterial(this.params.value)
      }
    })
  }

  deleteMaterial(id:string){
    this.materialService.deleteMaterial(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.materialListComponent.deleteData = false;
          this.materialListComponent.getAllMaterial();
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
