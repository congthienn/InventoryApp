import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddInventoryDeliveryVoucherModule } from './add-inventory-delivery-voucher/add-inventory-delivery-voucher.module';
import { InventoryDeliveryVoucherListModule } from './inventory-delivery-voucher-list/inventory-delivery-voucher-list.module';
import { InventoryDeliveryVoucherDetailModule } from './inventory-delivery-voucher-detail/inventory-delivery-voucher-detail.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InventoryDeliveryVoucherListModule,
    AddInventoryDeliveryVoucherModule,
    InventoryDeliveryVoucherDetailModule
  ]
})
export class InventoryDeliveryVoucherModule { }
