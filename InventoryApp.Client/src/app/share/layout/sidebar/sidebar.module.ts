import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [BrowserModule, NgbModule, FontAwesomeModule, RouterModule],
  declarations: [
    SidebarComponent
  ],
  exports:[
    SidebarComponent
  ]
})
export class SidebarModule { }
