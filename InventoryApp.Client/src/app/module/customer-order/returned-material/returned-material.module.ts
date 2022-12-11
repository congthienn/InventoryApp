import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReturnedMaterialComponent } from './returned-material.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { QuillModule } from 'ngx-quill';



@NgModule({
  declarations: [
    ReturnedMaterialComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module,
    AgGridModule,
    PageTitleModule,
    QuillModule,
    
  ]
})
export class ReturnedMaterialModule { }
