import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentComponent } from './shipment.component';
import { AddShipmentModule } from './add-shipment/add-shipment.module';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';


@NgModule({
  declarations: [
    ShipmentComponent
  ],
  imports: [
    CommonModule,
    ShipmentRoutingModule,
    AddShipmentModule,
    PageTitleModule, 
    AgGridModule
  ],
  exports:[ShipmentComponent]
})
export class ShipmentModule { }
