import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialRoutingModule } from './material-routing.module';
import { AddMaterialModule } from './add-material/add-material.module';
import { FormsModule } from '@angular/forms';
import { MaterialListModule } from './material-list/material-list.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    MaterialRoutingModule,
    AddMaterialModule,
    MaterialListModule
  ]
})
export class MaterialModule { }
