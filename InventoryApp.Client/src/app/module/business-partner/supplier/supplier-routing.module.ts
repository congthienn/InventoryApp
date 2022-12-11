import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { AddSupplierComponent } from './add-supplier/add-supplier.component';
import { SupplierListComponent } from './supplier-list/supplier-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'nha-cung-cap', pathMatch:'full'},
  { path: '', children: [ {path: '', component: SupplierListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"} }]}, 
  { path: '', children: [ {path: 'them-moi', component: AddSupplierComponent,  canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"} }]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupplierRoutingModule { }
