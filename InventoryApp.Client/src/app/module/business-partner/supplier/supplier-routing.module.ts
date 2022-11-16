import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSupplierComponent } from './add-supplier/add-supplier.component';
import { SupplierListComponent } from './supplier-list/supplier-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'nha-cung-cap', pathMatch:'full'},
  { path: '', children: [ {path: '', component: SupplierListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddSupplierComponent}]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupplierRoutingModule { }
