import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AddCustomerModule } from './add-customer/add-customer.module';
import { CustomerListModule } from './customer-list/customer-list.module';
import { AgGridModule } from 'ag-grid-angular';
import { CustomerGroupModule } from './customer-group/customer-group.module';
import { AddCustomerGroupModule } from './customer-group/add-customer-group/add-customer-group.module';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    AddCustomerModule,
    AgGridModule,
    CustomerGroupModule,
    AddCustomerGroupModule,
    CustomerListModule,
  ]
})
export class CustomerModule { }
