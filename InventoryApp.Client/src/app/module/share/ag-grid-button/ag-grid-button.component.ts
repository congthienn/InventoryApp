import { Component, OnInit } from '@angular/core';

import { ICellRendererAngularComp } from 'ag-grid-angular';
import {  }  from '@fortawesome/free-solid-svg-icons';
import { SweetalertService } from '../sweetalert/sweetalert.service';
@Component({
  selector: 'app-ag-grid-button',
  templateUrl: './ag-grid-button.component.html',
  styleUrls: ['./ag-grid-button.component.css']
})
export class BtnCellRenderer implements ICellRendererAngularComp {
  constructor(private sweetalertService: SweetalertService){}
  refresh() {
    return false;
  }
  private params: any;

  agInit(params: any): void {
    this.params = params;
  }

  btnDelete() {
    this.sweetalertService.alertDelete();
  }
  btnUpdate(){
    console.log(this.params.value);
  } 
}
