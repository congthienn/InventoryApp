import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryReceivingVoucherListModule } from './inventory-receiving-voucher-list/inventory-receiving-voucher-list.module';
import { AddInventoryReceivingVoucherModule } from './add-inventory-receiving-voucher/add-inventory-receiving-voucher.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InventoryReceivingVoucherListModule,
    AddInventoryReceivingVoucherModule
  ]
})
export class InventoryReceivingVoucherModule { }
