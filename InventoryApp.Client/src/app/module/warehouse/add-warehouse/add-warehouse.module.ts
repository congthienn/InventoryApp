import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddWarehouseComponent } from './add-warehouse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';
import { WarehouseListComponent } from '../warehouse-list/warehouse-list.component';
import { Router } from '@angular/router';
import { WarehouseListModule } from '../warehouse-list/warehouse-list.module';



@NgModule({
  declarations: [
    AddWarehouseComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module,
    WarehouseListModule
  ],
  exports: [AddWarehouseComponent]
})
export class AddWarehouseModule { }
