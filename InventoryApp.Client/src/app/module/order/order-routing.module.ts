import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { AddOrderComponent } from './add-order/add-order.component';
import { OrderListComponent } from './order-list/order-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'dat-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: OrderListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddOrderComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
