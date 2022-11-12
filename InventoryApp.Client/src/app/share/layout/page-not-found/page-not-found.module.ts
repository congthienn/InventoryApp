import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorRoutingModule } from './page-not-found-routing.module';
import { ErrorComponent } from './page-not-found.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    ErrorComponent
  ],
  imports: [
    CommonModule,
    ErrorRoutingModule,
    RouterModule,
  ]
})
export class ErrorModule { }
