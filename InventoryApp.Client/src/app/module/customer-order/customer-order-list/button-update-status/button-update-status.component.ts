import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { CustomerOrder } from '../../model/customer-order';
import { CustomerOrderService } from '../../service/customer-order.service';
import { CustomerOrderListComponent } from '../customer-order-list.component';

@Component({
  selector: 'app-button-update-status',
  templateUrl: './button-update-status.component.html',
  styleUrls: ['./button-update-status.component.css']
})
export class ButtonUpdateStatusComponent implements ICellRendererAngularComp {
  public params: any;
  public status!: string;
  public statusClass!:string;
  public order!:CustomerOrder;
  public disableButton = false;
  constructor(private customerOrderService: CustomerOrderService, private  sweetalertService: SweetalertService,
    private customerOrderListComponent: CustomerOrderListComponent
  ) { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.params = params; 
    this.getOrder();
  }
  getOrder(){
    return this.customerOrderService.getCustomerOrderByCode(this.params.value).subscribe(
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
    this.customerOrderService.updateStatus(this.params.value).subscribe(
      response => {
        this.customerOrderListComponent.refreshData();
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
        return "Đã xuất kho";
      case 3: 
        return "Đang giao hàng"
      case 4: 
        return "Giao hàng thành công"
      default:
          return "Đang xử lý";
    }
  }
  private getNextStatus(status: number): string {
    switch(status) {      
      case 1:      
          return "Tiến hành xuất kho";  
      case 2:      
          return "Vận chuyển - Giao hàng";  
      default:
          return "Phê duyệt đơn đặt hàng";
    }
  }
}