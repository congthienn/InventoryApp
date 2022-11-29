import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list.component';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';
import { ActionButtonComponent } from './action-button/action-button.component';



@NgModule({
  declarations: [
    EmployeeListComponent,
    ButtonUpdateStatusComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  exports: [EmployeeListComponent] 
})
export class EmployeeListModule { }
