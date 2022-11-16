import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCustomerGroupComponent } from './add-customer-group.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerGroupComponent } from '../customer-group.component';
import { AddCustomerComponent } from '../../add-customer/add-customer.component';

@NgModule({
  declarations: [
    AddCustomerGroupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers:[AddCustomerComponent]
})
export class AddCustomerGroupModule { }
