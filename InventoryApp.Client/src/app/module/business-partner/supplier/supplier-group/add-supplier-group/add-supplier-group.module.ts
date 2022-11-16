import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSupplierGroupComponent } from './add-supplier-group.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SupplierGroupComponent } from '../supplier-group.component';



@NgModule({
  declarations: [
    AddSupplierGroupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers:[SupplierGroupComponent],
  exports: [AddSupplierGroupComponent]
})
export class AddSupplierGroupModule { }
