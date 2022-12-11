import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AddInventoryDeliveryVoucherComponent } from './add-inventory-delivery-voucher.component';



@NgModule({
  declarations: [AddInventoryDeliveryVoucherComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module, 
    AgGridModule,
    PageTitleModule  
  ],
  exports:[AddInventoryDeliveryVoucherComponent]
})
export class AddInventoryDeliveryVoucherModule { }
