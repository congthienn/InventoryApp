import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { AddEmployeeComponent } from './add-employee/add-employee.component';

import { EmployeeListComponent } from './employee-list/employee-list.component';
import { UserListComponent } from './user-list/user-list.component';

export const routes: Routes = [
  { path: '', redirectTo:'nhan-vien', pathMatch:'full'},
  { path: 'tai-khoan', children: [ {path: '', component: UserListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]}, 
  { path: '', children: [ {path: '', component: EmployeeListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]},
  { path: '', children: [ {path: 'them-moi', component: AddEmployeeComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]},  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
