import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { AddMaterialComponent } from './add-material/add-material.component';
import { MaterialListComponent } from './material-list/material-list.component';
import { MaterialPositionComponent } from './material-position/material-position.component';

export const routes: Routes = [
  {path: '', redirectTo:'san-pham', pathMatch:'full'},
  { path: '', children: [ {path: '', component: MaterialListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho,Nhân viên bán hàng"} }]}, 
  { path: '', children: [ {path: 'them-moi', component: AddMaterialComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]},
  { path: '', children: [ {path: 'vi-tri', component: MaterialPositionComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho,Nhân viên bán hàng"}}]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaterialRoutingModule { }
