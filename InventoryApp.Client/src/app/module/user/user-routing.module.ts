import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'tai-khoan', pathMatch:'full'},
  { path: '', children: [ {path: '', component: UserListComponent}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
