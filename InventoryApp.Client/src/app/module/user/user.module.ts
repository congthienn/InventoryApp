import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserListModule } from './user-list/user-list.module';
import { RouterModule } from '@angular/router';
import { AddUserModule } from './add-user/add-user.module';
import { AddEmployeeModule } from './add-employee/add-employee.module';
import { EmployeeListModule } from './employee-list/employee-list.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UserRoutingModule,
    UserListModule,
    AddUserModule,
    AddEmployeeModule,
    EmployeeListModule,
    RouterModule
  ]
})
export class UserModule { }
