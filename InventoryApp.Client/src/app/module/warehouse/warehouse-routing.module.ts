import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWarehouseComponent } from './add-warehouse/add-warehouse.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'kho-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: WarehouseListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddWarehouseComponent}]},
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
