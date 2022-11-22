import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { WarehouseAreaService } from '../../service/warehouse-area.service';
import { WarehouseLayoutComponent } from '../../warehouse-layout.component';

@Component({
  selector: 'app-action-buton',
  templateUrl: './action-buton.component.html',
  styleUrls: ['./action-buton.component.css']
})
export class ActionButonComponent implements ICellRendererAngularComp {
  constructor(
    private warehouseAreaService: WarehouseAreaService,
    private sweetalertService : SweetalertService,
    private warehouseLayoutComponent: WarehouseLayoutComponent
    ){}
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
        this.deleteWarehouseArea(this.params.value)
      }
    })
  }

  deleteWarehouseArea(id:string){
    this.warehouseAreaService.deleteWarehouseArea(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.warehouseLayoutComponent.getWarehouseArea();
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
