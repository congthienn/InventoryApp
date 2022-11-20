import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryReceivingVoucherListComponent } from './inventory-receiving-voucher-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({ 
  declarations: [
    InventoryReceivingVoucherListComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  exports: [InventoryReceivingVoucherListComponent]
})
export class InventoryReceivingVoucherListModule { }
