import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';
import { UserListComponent } from '../user-list/user-list.component';



@NgModule({
  declarations: [
    AddUserComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module,
  ],
  exports: [AddUserComponent]
})
export class AddUserModule { }
