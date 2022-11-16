import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrademarkComponent } from './trademark.component';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddTrademarkModule } from './add-trademark/add-trademark.module';
import { TrademarkActionButtonComponent } from './trademark-action-button/trademark-action-button.component';



@NgModule({
  declarations: [
    TrademarkComponent,
    TrademarkActionButtonComponent
  ],
  imports: [
    CommonModule,
    AgGridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    AddTrademarkModule
  ],
  exports: [TrademarkComponent]
})
export class TrademarkModule { }
