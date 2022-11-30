import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyInformationComponent } from './company-information/company-information.component';

export const routes: Routes = [
  { path: '', children: [ {path: 'thong-tin-cong-ty', component: CompanyInformationComponent}]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneralRoutingModule { }
