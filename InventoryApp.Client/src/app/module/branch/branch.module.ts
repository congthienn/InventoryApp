import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchRoutingModule } from './branch-routing.module';
import { BranchListModule } from './branch-list/branch-list.module';
import { AddBranchModule } from './add-branch/add-branch.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BranchRoutingModule,
    RouterModule,
    BranchListModule,
    AddBranchModule
  ]
})
export class BranchModule { }
