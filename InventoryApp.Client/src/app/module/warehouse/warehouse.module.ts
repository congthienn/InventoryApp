import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { AddWarehouseModule } from './add-warehouse/add-warehouse.module';
import { WarehouseListModule } from './warehouse-list/warehouse-list.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    WarehouseRoutingModule,
    AddWarehouseModule,
    WarehouseListModule
  ]
})
export class WarehouseModule { }
