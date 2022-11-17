import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddMaterialComponent } from './add-material/add-material.component';
import { MaterialListComponent } from './material-list/material-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'san-pham', pathMatch:'full'},
  { path: '', children: [ {path: '', component: MaterialListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddMaterialComponent}]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaterialRoutingModule { }
