import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeliveryCompanyRoutingModule } from './delivery-company-routing.module';
import { DeliveryCompanyListModule } from './delivery-company-list/delivery-company-list.module';
import { DeliveryCompanyAddModule } from './delivery-company-add/delivery-company-add.module';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    DeliveryCompanyRoutingModule,
    DeliveryCompanyListModule,
    DeliveryCompanyAddModule
  ]
})
export class DeliveryCompanyModule { }
