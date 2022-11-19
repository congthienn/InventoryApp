import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { Order } from '../../model/order';
import { OrderDetailComponent } from '../../order-detail/order-detail.component';
import { OrderService } from '../../service/order.service';
import { OrderListComponent } from '../order-list.component';

@Component({
  selector: 'app-button-update-status',
  templateUrl: './button-update-status.component.html',
  styleUrls: ['./button-update-status.component.css']
})
export class ButtonUpdateStatusComponent implements ICellRendererAngularComp {
  public params: any;
  public status!: string;
  public statusClass!:string;
  public order!:Order;
  constructor(private orderService: OrderService, private  sweetalertService: SweetalertService,
    private orderListComponent: OrderListComponent
  ) { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.params = params; 
    this.getOrder();
  }
  getOrder(){
    return this.orderService.getOrderByCode(this.params.value).subscribe(
      response => {
        this.order = response;
        this.statusClass = this.getColorStatus(Number(this.order.status));
        this.status = this.getStatus(Number(this.order.status));
      }
    )
  }
  btnUpdateStatus() {  
    Swal.fire({
      title: 'Cập nhật trạng thái đơn đặt hàng',
      text: this.getNextStatus(Number(this.order.status)),
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Cập nhật',
      cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
      if (result.isConfirmed) {    
        this.updateOrderStatus();
      }
    })
  }
  private updateOrderStatus(){
    this.orderService.updateStatus(this.params.value).subscribe(
      response => {
        this.orderListComponent.refreshData();
        this.sweetalertService.alertMini("Cập nhật trạng thái thành công","", 'success');  
    },
    error =>{
      this.sweetalertService.alertMini("Không thể cập nhật","Vui lòng kiểm tra lại", 'error');
    })
  }
  private getColorStatus(status: number): string {
    switch(status) {      
      case 1:      
          return "btn-info";  
      case 2:
        return "btn-primary";
      case 3: 
        return "btn-success"
      default:
          return "btn-danger";
    }
  }
  private getStatus(status: number): string {
    switch(status) {      
      case 1:      
          return "Đã phê duyệt";  
      case 2:
        return "Đã đặt hàng";
      case 3: 
        return "Đã nhập kho"
      default:
          return "Đang chờ phê duyệt";
    }
  }
  private getNextStatus(status: number): string {
    switch(status) {      
      case 1:      
          return "Tiến hành đặt hàng";  
      default:
          return "Phê duyệt đơn đặt hàng";
    }
  }
}