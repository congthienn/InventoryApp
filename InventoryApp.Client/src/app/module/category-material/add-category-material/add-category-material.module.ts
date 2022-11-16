import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCategoryMaterialComponent } from './add-category-material.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AddCategoryMaterialComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AddCategoryMaterialModule { }
