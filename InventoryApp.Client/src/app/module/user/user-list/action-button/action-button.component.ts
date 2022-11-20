import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { MaterialListComponent } from 'src/app/module/material/material-list/material-list.component';
import { MaterialService } from 'src/app/module/material/service/material.service';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.css']
})
export class ActionButtonComponent implements ICellRendererAngularComp {
  constructor(){}
  private params: any;
  public clickDelete = false;
  refresh() {
    return false;
  }
  agInit(params: any): void {
    this.params = params;
  }

 
}
