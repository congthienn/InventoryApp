import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentComponent } from './shipment.component';
import { AddShipmentModule } from './add-shipment/add-shipment.module';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { ButtonShipmentStatusComponent } from './button-shipment-status/button-shipment-status.component';
import { NgSelect2Module } from 'ng-select2';


@NgModule({
  declarations: [
    ShipmentComponent,
    ButtonShipmentStatusComponent
  ],
  imports: [
    CommonModule,
    ShipmentRoutingModule,
    AddShipmentModule,
    PageTitleModule, 
    AgGridModule,
    NgSelect2Module,
  ],
  exports:[ShipmentComponent]
})
export class ShipmentModule { }
