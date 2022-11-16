import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AddCustomerModule } from './add-customer/add-customer.module';
import { CustomerListModule } from './customer-list/customer-list.module';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    AddCustomerModule,
    CustomerListModule,
    AgGridModule
  ]
})
export class CustomerModule { }
