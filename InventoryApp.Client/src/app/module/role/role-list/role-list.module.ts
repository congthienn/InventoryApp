import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleListComponent } from './role-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonComponent } from './action-button/action-button.component';



@NgModule({
  declarations: [
    RoleListComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule,
    AgGridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class RoleListModule { }
