import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { OrderDetailComponent } from '../../order-detail/order-detail.component';
import { OrderService } from '../../service/order.service';

@Component({
  selector: 'app-action-button-view-detail',
  templateUrl: './action-button-view-detail.component.html',
  styleUrls: ['./action-button-view-detail.component.css']
})
export class ActionButtonViewDetailComponent implements ICellRendererAngularComp {
  private params: any;
  clickDelete = false;
  constructor( private orderService: OrderService,
    private modalService: NgbModal
  ) { }
  refresh() {
    return false;
  }
  agInit(params: any): void {
    this.params = params;
  }
  btnOrderDetail() {  
    const modalRef  = this.modalService.open(OrderDetailComponent, {size:"lg" });
    modalRef.componentInstance.id = this.params.value;
  }
}
