import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneralRoutingModule } from './general-routing.module';
import { CompanyInformationModule } from './company-information/company-information.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    GeneralRoutingModule,
    CompanyInformationModule
  ]
})
export class GeneralModule { }
