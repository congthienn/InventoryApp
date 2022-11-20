import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleListModule } from './role-list/role-list.module';
import { AddRoleModule } from './add-role/add-role.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RoleListModule,
    AddRoleModule
  ]
})
export class RoleModule { }
