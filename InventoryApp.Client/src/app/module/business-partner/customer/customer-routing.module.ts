import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { CustomerListComponent } from './customer-list/customer-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'khach-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: CustomerListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddCustomerComponent}]}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
