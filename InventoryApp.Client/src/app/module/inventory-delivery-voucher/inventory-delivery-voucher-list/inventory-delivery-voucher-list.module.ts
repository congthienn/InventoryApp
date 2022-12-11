import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { InventoryDeliveryVoucherListComponent } from './inventory-delivery-voucher-list.component';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { NgSelect2Module } from 'ng-select2';



@NgModule({
  declarations: [InventoryDeliveryVoucherListComponent, ActionButtonViewDetailComponent],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule, NgSelect2Module 
  ],
  exports:[InventoryDeliveryVoucherListComponent]
})
export class InventoryDeliveryVoucherListModule { }
