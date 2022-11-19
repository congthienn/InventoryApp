import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddOrderComponent } from './add-order/add-order.component';
import { OrderListComponent } from './order-list/order-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'dat-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: OrderListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddOrderComponent}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
