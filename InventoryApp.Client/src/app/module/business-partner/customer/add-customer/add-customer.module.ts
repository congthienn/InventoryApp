import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCustomerComponent } from './add-customer.component';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';



@NgModule({
  declarations: [
    AddCustomerComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    PageTitleModule,
    NgSelect2Module
  ],
  exports: [AddCustomerComponent]
})
export class AddCustomerModule { }
