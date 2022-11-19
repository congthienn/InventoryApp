import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerOrderComponent } from './add-customer-order/add-customer-order.component';
import { CustomerOrderListComponent } from './customer-order-list/customer-order-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'don-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: CustomerOrderListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddCustomerOrderComponent}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerOrderRoutingModule { }
