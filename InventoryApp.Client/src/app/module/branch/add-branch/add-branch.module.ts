import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddBranchComponent } from './add-branch.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from 'src/app/share/layout/layout.module';
import { PageTitleModule } from 'src/app/share/layout/page-title/page-title.module';



@NgModule({
  declarations: [AddBranchComponent],
  imports: [
    CommonModule,
    RouterModule,
    PageTitleModule
  ],
  exports: [AddBranchComponent]
})
export class AddBranchModule { }
