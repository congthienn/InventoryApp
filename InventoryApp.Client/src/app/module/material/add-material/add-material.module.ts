import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddMaterialComponent } from './add-material.component';
import { RouterModule } from '@angular/router';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { NgSelect2Module } from 'ng-select2';
import { QuillModule } from 'ngx-quill'
import { NgxDropzoneModule } from 'ngx-dropzone';
import { TrademarkModule } from '../../trademark/trademark.module';
@NgModule({
  declarations: [
    AddMaterialComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    PageTitleModule,
    NgSelect2Module,
    QuillModule,
    NgxDropzoneModule,
    TrademarkModule
  ]
})
export class AddMaterialModule { }
