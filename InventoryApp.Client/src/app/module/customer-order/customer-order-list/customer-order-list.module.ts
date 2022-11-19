import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerOrderListComponent } from './customer-order-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';



@NgModule({
  declarations: [
    CustomerOrderListComponent,
    ActionButtonViewDetailComponent,
    ButtonUpdateStatusComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  exports: [CustomerOrderListComponent]
})
export class CustomerOrderListModule { }
