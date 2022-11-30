import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { CustomerOrder } from '../../model/customer-order';
import { CustomerOrderService } from '../../service/customer-order.service';
import { CustomerOrderListComponent } from '../customer-order-list.component';

@Component({
  selector: 'app-button-payment-status',
  templateUrl: './button-payment-status.component.html',
  styleUrls: ['./button-payment-status.component.css']
})
export class ButtonPaymentStatusComponent implements ICellRendererAngularComp {
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
        this.statusClass = this.order.paid ? "btn-success" : "btn-danger";
        this.status = this.order.paid ? "Đã thanh toán đủ" : "Chưa thanh toán đủ";
        this.disableButton = !this.order.paid && Number(this.order.status) == 4;
      }
    )
  }
  btnUpdateOrderPayment() {  
    Swal.fire({
      title: 'Cập nhật thanh toán đơn đặt hàng',
      text: 'Xác nhận đơn hàng đã được thanh toán',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Cập nhật',
      cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
      if (result.isConfirmed) {    
        this.updateOrderPayment();
      }
    })
  }
  private updateOrderPayment(){
    this.customerOrderService.updateOrderPayment(this.params.value).subscribe(
      response => {
        this.customerOrderListComponent.refreshData();
        this.sweetalertService.alertMini("Cập nhật trạng thái thành công","", 'success');  
    },
    error =>{
      this.sweetalertService.alertMini("Không thể cập nhật","Vui lòng kiểm tra lại", 'error');
    })
  }
}
