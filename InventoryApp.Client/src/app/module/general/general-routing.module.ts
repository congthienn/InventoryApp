import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { CompanyInformationComponent } from './company-information/company-information.component';

export const routes: Routes = [
  { path: '', children: [ {path: 'thong-tin-cong-ty', component: CompanyInformationComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneralRoutingModule { }
