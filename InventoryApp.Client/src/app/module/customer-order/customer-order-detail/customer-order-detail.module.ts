import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerOrderDetailComponent } from './customer-order-detail.component';



@NgModule({
  declarations: [
    CustomerOrderDetailComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [CustomerOrderDetailComponent]
})
export class CustomerOrderDetailModule { }
