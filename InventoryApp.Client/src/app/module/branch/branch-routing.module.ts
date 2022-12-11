import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';
import { AddBranchComponent } from './add-branch/add-branch.component';
import { BranchListComponent } from './branch-list/branch-list.component';
import { Title } from '@angular/platform-browser';
import { RoleGuard } from 'src/app/auth/role.guard';
export const routes: Routes = [
  {path: '', redirectTo:'chi-nhanh', pathMatch:'full'},
  { path: '', children: [ {path: '', component: BranchListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddBranchComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchRoutingModule { }
