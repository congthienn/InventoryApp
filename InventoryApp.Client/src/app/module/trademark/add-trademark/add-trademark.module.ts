import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddTrademarkComponent } from './add-trademark.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddTrademarkComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AddTrademarkModule { }
