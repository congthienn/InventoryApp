import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeliveryCompanyListComponent } from './delivery-company-list.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AgGridModule } from 'ag-grid-angular';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { ActionButtonComponent } from './action-button/action-button.component';



@NgModule({
  declarations: [DeliveryCompanyListComponent, ActionButtonComponent],
  imports: [
    CommonModule, PageTitleModule, RouterModule, NgbModule, AgGridModule, NgSelect2Module,
  ],
  exports: [DeliveryCompanyListComponent]
})
export class DeliveryCompanyListModule { }
