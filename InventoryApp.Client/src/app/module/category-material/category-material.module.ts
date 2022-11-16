import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryMaterialComponent } from './category-material.component';
import { AddCategoryMaterialModule } from './add-category-material/add-category-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonComponent } from './action-button/action-button.component';



@NgModule({
  declarations: [
    CategoryMaterialComponent,
    ActionButtonComponent
  ],
  imports: [
    CommonModule,
    AgGridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    AddCategoryMaterialModule
  ]
})
export class CategoryMaterialModule { }
