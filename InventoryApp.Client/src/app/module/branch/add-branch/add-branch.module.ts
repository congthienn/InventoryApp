import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddBranchComponent } from './add-branch.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from 'src/app/share/layout/layout.module';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';



@NgModule({
  declarations: [AddBranchComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    PageTitleModule,
    NgSelect2Module
  ],
  exports: [AddBranchComponent]
})
export class AddBranchModule { }
