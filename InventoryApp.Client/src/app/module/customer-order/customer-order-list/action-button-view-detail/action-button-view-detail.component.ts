import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { CustomerOrderDetailComponent } from '../../customer-order-detail/customer-order-detail.component';
import { ReturnedMaterialComponent } from '../../returned-material/returned-material.component';
import { CustomerOrderService } from '../../service/customer-order.service';

@Component({
  selector: 'app-action-button-view-detail',
  templateUrl: './action-button-view-detail.component.html',
  styleUrls: ['./action-button-view-detail.component.css']
})
export class ActionButtonViewDetailComponent implements ICellRendererAngularComp {

  private params: any;
  public actionString = '';
  public actionClass = '';
  public disableButton = false;
  public cancelOrder = true;
  clickDelete = false;
  constructor(
    private modalService: NgbModal,
    private customerOrderService: CustomerOrderService
  ) { }
  refresh() {
    return false;
  }   
  agInit(params: any): void {
    this.params = params;
    this.getCustomerOrder();
    
  }
  getCustomerOrder(){
    this.customerOrderService.getCustomerOrderByCode(this.params.value).subscribe(
      response => {
        this.actionString = this.getStringButton(response.status);
        this.actionClass = this.getClassButton(response.status);
        this.disableButton = response.status == 3;
        this.cancelOrder =  response.status != 4;
      }
    )
  }
  getStringButton(status: number): string {
    switch (status) {
      case 5: 
        return "Đã xử lý";
      case 4:
        return "Trả hàng";
      case 3: 
        return "GH thất bại";
      default: 
        return "Hủy đơn";
    }
  }

  getClassButton(status: number): string {
    switch (status) {
      case 5: 
        return "btn-info";
      case 4:
        return "btn-warning";
      default: 
        return "btn-danger";
    }
  }
  btnOrderDetail() {  
    const modalRef  = this.modalService.open(CustomerOrderDetailComponent, {size:"lg" });
    modalRef.componentInstance.id = this.params.value;
  }
  btnAction(){
    if(this.cancelOrder)
      return;
    this.returnedMaterial();
  }
  returnedMaterial(){
    const modalRef  = this.modalService.open(ReturnedMaterialComponent, {size:"lg" });
    modalRef.result.then((result) => {
      this.getCustomerOrder();
    },(reason) => {
      this.getCustomerOrder();
    });
    modalRef.componentInstance.id = this.params.value;
  }
}
