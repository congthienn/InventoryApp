import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductStatisticsComponent } from './product-statistics.component';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { ButtonStatusComponent } from './button-status/button-status.component';



@NgModule({
  declarations: [
    ProductStatisticsComponent,
    ButtonStatusComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule, NgSelect2Module
  ],
  exports:[ProductStatisticsComponent]
})
export class ProductStatisticsModule { }
