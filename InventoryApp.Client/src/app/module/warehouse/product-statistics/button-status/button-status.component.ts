import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-button-status',
  templateUrl: './button-status.component.html',
  styleUrls: ['./button-status.component.css']
})
export class ButtonStatusComponent implements ICellRendererAngularComp {
  public status!: string;
  public statusClass!:string;
  public disableButton = false;
  constructor() { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.statusClass = this.setClass(params.value);
    this.status = params.value;
  }

  setClass(status:string): string {

    switch(status) {
      case "Sắp hết hàng":
        return "btn-warning";
      case "Hết hàng": 
        return "btn-danger";
      case "Vượt giới hạn": 
        return "btn-danger";
      default: return "btn-primary";
    }

  }
}
