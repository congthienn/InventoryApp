import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SupplierRoutingModule } from './supplier-routing.module';
import { AddSupplierModule } from './add-supplier/add-supplier.module';
import { SupplierGroupModule } from './supplier-group/supplier-group.module';
import { AgGridModule } from 'ag-grid-angular';
import { AddSupplierGroupModule } from './supplier-group/add-supplier-group/add-supplier-group.module';
import { SupplierListModule } from './supplier-list/supplier-list.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SupplierRoutingModule,
    AddSupplierModule,
    SupplierGroupModule,
    AgGridModule,
    AddSupplierGroupModule,
    SupplierListModule
  ]
})
export class SupplierModule { }
