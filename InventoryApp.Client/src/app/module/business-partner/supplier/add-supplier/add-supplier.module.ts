import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSupplierComponent } from './add-supplier.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { NgSelect2Module } from 'ng-select2';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AddSupplierComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    PageTitleModule,
    NgSelect2Module
  ],
  exports:[AddSupplierComponent]
})
export class AddSupplierModule { }
