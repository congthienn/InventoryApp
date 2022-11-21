import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddShipmentComponent } from './add-shipment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddShipmentComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports:[AddShipmentComponent]
})
export class AddShipmentModule { }
