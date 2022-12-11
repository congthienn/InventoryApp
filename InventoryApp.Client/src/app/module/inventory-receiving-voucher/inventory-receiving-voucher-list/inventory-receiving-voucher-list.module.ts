import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryReceivingVoucherListComponent } from './inventory-receiving-voucher-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { NgSelect2Module } from 'ng-select2';

@NgModule({ 
  declarations: [
    InventoryReceivingVoucherListComponent,
    ActionButtonViewDetailComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule, NgSelect2Module  
  ],
  exports: [InventoryReceivingVoucherListComponent]
})
export class InventoryReceivingVoucherListModule { }
