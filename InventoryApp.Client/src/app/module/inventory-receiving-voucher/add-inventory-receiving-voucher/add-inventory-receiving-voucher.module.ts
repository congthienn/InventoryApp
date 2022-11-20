import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddInventoryReceivingVoucherComponent } from './add-inventory-receiving-voucher.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';



@NgModule({
  declarations: [
    AddInventoryReceivingVoucherComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module, 
    AgGridModule,
    PageTitleModule 
  ],
  exports: [AddInventoryReceivingVoucherComponent]
})
export class AddInventoryReceivingVoucherModule { }
