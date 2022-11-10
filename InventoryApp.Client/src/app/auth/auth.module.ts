import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { LoginModule } from './login/login.module';
import { AuthRoutingModule } from './auth-routing.module';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LoginModule,
    BrowserModule,
    AuthRoutingModule,
    
  ],
  providers:[DatePipe],
  exports: [
    LoginModule
  ]
})
export class AuthModule { }
