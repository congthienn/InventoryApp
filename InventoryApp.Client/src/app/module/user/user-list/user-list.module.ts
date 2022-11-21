import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';
import { ActionButtonComponent } from './action-button/action-button.component';
import { AddUserComponent } from '../add-user/add-user.component';



@NgModule({
  declarations: [
    UserListComponent,
    ButtonUpdateStatusComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  providers:[AddUserComponent], 
  exports: [UserListComponent]
})
export class UserListModule { }
