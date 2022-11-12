import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from './branch-list.component';



@NgModule({
  declarations: [
    BranchListComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    BranchListComponent
  ]
})
export class BranchListModule { }
