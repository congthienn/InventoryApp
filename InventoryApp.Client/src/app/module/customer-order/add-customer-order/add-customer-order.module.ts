import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCustomerOrderComponent } from './add-customer-order.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';



@NgModule({
  declarations: [
    AddCustomerOrderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module,
    AgGridModule,
    PageTitleModule 
  ],
  exports:[AddCustomerOrderComponent]
})
export class AddCustomerOrderModule { }
