import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { AuthService } from 'src/app/auth/auth.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { WarehouseLineService } from '../../service/warehouse-line.service';
import { WarehouseShelveService } from '../../service/warehouse-shelve.service';
import { WarehouseLayoutComponent } from '../../warehouse-layout.component';

@Component({
  selector: 'app-action-button-warehouse-shelve',
  templateUrl: './action-button-warehouse-shelve.component.html',
  styleUrls: ['./action-button-warehouse-shelve.component.css']
})
export class ActionButtonWarehouseShelveComponent implements ICellRendererAngularComp {
  constructor(
    private warehouseShelveService: WarehouseShelveService,
    private sweetalertService : SweetalertService,
    private warehouseLayoutComponent: WarehouseLayoutComponent,
    private authService : AuthService,
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
        this.deleteWarehouseLine(this.params.value)
      }
    })
  }

  deleteWarehouseLine(id:string){
    this.warehouseShelveService.deleteWarehouseShelve(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.warehouseLayoutComponent.getWarehouseShelve();
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
