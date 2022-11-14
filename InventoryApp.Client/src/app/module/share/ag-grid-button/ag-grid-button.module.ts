import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BtnCellRenderer } from './ag-grid-button.component';



@NgModule({
  declarations: [
    BtnCellRenderer
  ],
  imports: [
    CommonModule
  ],
  exports:[BtnCellRenderer]
})
export class AgGridButtonModule { }
