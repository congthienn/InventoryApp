import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { LoginModule } from './login/login.module';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LoginModule,
    BrowserModule,    
  ],
  providers:[DatePipe],
  exports: [
    LoginModule
  ]
})
export class AuthModule { }
