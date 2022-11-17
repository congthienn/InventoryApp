import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WarehouseListComponent } from './warehouse-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { ActionButtonWarehouseComponent } from './action-button-warehouse/action-button-warehouse.component';
import { AddWarehouseComponent } from '../add-warehouse/add-warehouse.component';



@NgModule({
  declarations: [
    WarehouseListComponent,
    ActionButtonWarehouseComponent
  ],
  imports:  [CommonModule, PageTitleModule, AgGridModule, RouterModule],
  entryComponents: [AddWarehouseComponent],
  exports:[WarehouseListComponent]
})
export class WarehouseListModule { }
