import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { RouterModule } from '@angular/router';
import { CustomerGroupComponent } from '../customer-group/customer-group.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonComponent } from './action-button/action-button.component';

@NgModule({
  declarations: [
    CustomerListComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule, PageTitleModule, RouterModule, NgbModule, AgGridModule
  ],
  exports:[CustomerListComponent]
})
export class CustomerListModule { }