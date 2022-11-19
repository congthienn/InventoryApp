import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderListModule } from './order-list/order-list.module';
import { AddOrderModule } from './add-order/add-order.module';
import { OrderDetailModule } from './order-detail/order-detail.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    OrderRoutingModule,
    OrderListModule,
    AddOrderModule,
    OrderDetailModule
  ]
})
export class OrderModule { }
