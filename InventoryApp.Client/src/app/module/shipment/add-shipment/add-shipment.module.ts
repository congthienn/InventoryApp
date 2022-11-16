import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddShipmentComponent } from './add-shipment.component';



@NgModule({
  declarations: [
    AddShipmentComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[AddShipmentComponent]
})
export class AddShipmentModule { }
