import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerGroupComponent } from './customer-group.component';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonComponent } from './button/button.component';



@NgModule({
  declarations: [
    CustomerGroupComponent,
    ButtonComponent
  ],
  imports: [
    CommonModule,AgGridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [CustomerGroupComponent]
})
export class CustomerGroupModule { }
