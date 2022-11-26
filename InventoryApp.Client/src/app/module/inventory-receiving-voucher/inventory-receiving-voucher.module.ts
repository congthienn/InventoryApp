import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryReceivingVoucherListModule } from './inventory-receiving-voucher-list/inventory-receiving-voucher-list.module';
import { AddInventoryReceivingVoucherModule } from './add-inventory-receiving-voucher/add-inventory-receiving-voucher.module';
import { InventoryReceivingVoucherDetailModule } from './inventory-receiving-voucher-detail/inventory-receiving-voucher-detail.module';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    InventoryReceivingVoucherListModule,
    AddInventoryReceivingVoucherModule,
    InventoryReceivingVoucherDetailModule
  ]
})
export class InventoryReceivingVoucherModule { }
