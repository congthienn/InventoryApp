import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { DeliveryCompanyAddComponent } from './delivery-company-add/delivery-company-add.component';
import { DeliveryCompanyListComponent } from './delivery-company-list/delivery-company-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'doi-vi-giao-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: DeliveryCompanyListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho,Nhân viên bán hàng"} }]}, 
  { path: '', children: [ {path: 'them-moi', component: DeliveryCompanyAddComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"} }]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DeliveryCompanyRoutingModule { }
