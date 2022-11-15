import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from './branch-list.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    BranchListComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule],
  exports:[
    BranchListComponent
  ]
})
export class BranchListModule { }
  