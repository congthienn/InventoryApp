import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { AddWarehouseModule } from './add-warehouse/add-warehouse.module';
import { WarehouseListModule } from './warehouse-list/warehouse-list.module';
import { InventoryReceivingVoucherModule } from '../inventory-receiving-voucher/inventory-receiving-voucher.module';
import { InventoryDeliveryVoucherModule } from '../inventory-delivery-voucher/inventory-delivery-voucher.module';
import { ProductStatisticsModule } from './product-statistics/product-statistics.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    WarehouseRoutingModule,
    AddWarehouseModule,
    WarehouseListModule,
    InventoryReceivingVoucherModule,
    InventoryDeliveryVoucherModule,
    ProductStatisticsModule 
  ]
})
export class WarehouseModule { }
