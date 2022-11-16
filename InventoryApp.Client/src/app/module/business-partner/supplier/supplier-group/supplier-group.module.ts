import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupplierGroupComponent } from './supplier-group.component';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActionButtonComponent } from './action-button/action-button.component';



@NgModule({
  declarations: [
    SupplierGroupComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule,AgGridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [SupplierGroupComponent]
})
export class SupplierGroupModule { }
