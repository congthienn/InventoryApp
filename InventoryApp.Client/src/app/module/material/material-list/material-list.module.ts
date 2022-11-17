import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialListComponent } from './material-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { CurrencyComponent } from './currency/currency.component';
import { ActionButtonMaterialComponent } from './action-button-material/action-button-material.component';



@NgModule({
  declarations: [
    MaterialListComponent,
    CurrencyComponent,
    ActionButtonMaterialComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule
  ],
  exports: [MaterialListComponent]
})
export class MaterialListModule { }
