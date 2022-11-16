import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupplierListComponent } from './supplier-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonComponent } from './action-button/action-button.component';

@NgModule({
  declarations: [
    SupplierListComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule, PageTitleModule, RouterModule, NgbModule, AgGridModule
  ],
  exports: [SupplierListComponent]
})
export class SupplierListModule { }
