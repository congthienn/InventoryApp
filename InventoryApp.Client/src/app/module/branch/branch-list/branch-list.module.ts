import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from './branch-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  declarations: [
    BranchListComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule],
  exports:[
    BranchListComponent
  ]
})
export class BranchListModule { }
  