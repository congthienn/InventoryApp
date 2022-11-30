import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { CustomerOrder } from '../../customer-order/model/customer-order';

@Component({
  selector: 'app-button-shipment-status',
  templateUrl: './button-shipment-status.component.html',
  styleUrls: ['./button-shipment-status.component.css']
})
export class ButtonShipmentStatusComponent  implements ICellRendererAngularComp {
  public status!: string;
  public statusClass!:string;
  public disableButton = false;
  constructor() { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.statusClass = Number(params.value) == 0 ? "btn-danger" : "btn-success";
    this.status = Number(params.value) == 0 ? "Hết hàng" : "Còn hàng";
  }
}
