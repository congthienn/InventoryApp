import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerOrderRoutingModule } from './customer-order-routing.module';
import { AddCustomerOrderModule } from './add-customer-order/add-customer-order.module';
import { CustomerOrderListModule } from './customer-order-list/customer-order-list.module';
import { CustomerOrderDetailModule } from './customer-order-detail/customer-order-detail.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CustomerOrderRoutingModule,
    CustomerOrderListModule,
    AddCustomerOrderModule,
    CustomerOrderDetailModule
  ]
})
export class CustomerOrderModule { }
