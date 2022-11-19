import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './order-list.component';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';



@NgModule({
  declarations: [
    OrderListComponent,
    ActionButtonViewDetailComponent,
    ButtonUpdateStatusComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  exports: [OrderListComponent]
})
export class OrderListModule { }
