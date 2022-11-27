import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddMaterialComponent } from './add-material/add-material.component';
import { MaterialListComponent } from './material-list/material-list.component';
import { MaterialPositionComponent } from './material-position/material-position.component';

export const routes: Routes = [
  {path: '', redirectTo:'san-pham', pathMatch:'full'},
  { path: '', children: [ {path: '', component: MaterialListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddMaterialComponent}]},
  { path: '', children: [ {path: 'vi-tri', component: MaterialPositionComponent}]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaterialRoutingModule { }
