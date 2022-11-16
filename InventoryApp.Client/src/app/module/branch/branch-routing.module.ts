import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';
import { AddBranchComponent } from './add-branch/add-branch.component';
import { BranchListComponent } from './branch-list/branch-list.component';
import { Title } from '@angular/platform-browser';
export const routes: Routes = [
  {path: '', redirectTo:'chi-nhanh', pathMatch:'full'},
  { path: '', children: [ {path: '', component: BranchListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddBranchComponent}]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchRoutingModule { }
