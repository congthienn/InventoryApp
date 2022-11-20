import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddRoleComponent } from './add-role.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddRoleComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AddRoleModule { }
