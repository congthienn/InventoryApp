import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeliveryCompanyAddComponent } from './delivery-company-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgSelect2Module } from 'ng-select2';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';



@NgModule({
  declarations: [
    DeliveryCompanyAddComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    PageTitleModule,
    NgSelect2Module
  ]
})
export class DeliveryCompanyAddModule { }
