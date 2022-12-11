import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialPositionComponent } from './material-position.component';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { NgSelect2Module } from 'ng-select2';



@NgModule({
  declarations: [
    MaterialPositionComponent
  ],
  imports: [
    CommonModule, PageTitleModule, AgGridModule, RouterModule, NgSelect2Module 
  ]
})
export class MaterialPositionModule { }
