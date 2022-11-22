import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehouseLayoutRoutingModule } from './warehouse-layout-routing.module';
import { WarehouseLayoutComponent } from './warehouse-layout.component';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { NgSelect2Module } from 'ng-select2';
import { AddWarehouseAreaComponent } from './add-warehouse-area/add-warehouse-area.component';
import { AddWarehouseLineComponent } from './add-warehouse-line/add-warehouse-line.component';
import { AddWarehouseShelveComponent } from './add-warehouse-shelve/add-warehouse-shelve.component';
import { ActionButonComponent } from './add-warehouse-area/action-buton/action-buton.component';
import { ActionButtonWarehouseLineComponent } from './add-warehouse-line/action-button-warehouse-line/action-button-warehouse-line.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    WarehouseLayoutComponent,
    AddWarehouseAreaComponent,
    AddWarehouseLineComponent,
    AddWarehouseShelveComponent,
    ActionButonComponent,
    ActionButtonWarehouseLineComponent,
  ],
  imports: [
    CommonModule,
    WarehouseLayoutRoutingModule,
    PageTitleModule, 
    AgGridModule,
    RouterModule,
    NgSelect2Module,
    FormsModule,
    ReactiveFormsModule, 
  ]
})
export class WarehouseLayoutModule { }
