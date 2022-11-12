import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { LayoutModule } from './share/layout/layout.module';
import { AdminLayoutComponent } from './share/admin-layout/admin-layout.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BranchModule } from './module/branch/branch.module';
import { DashboardModule } from './module/dashboard/dashboard.module';

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent
  ],
  imports: [
    SimpleNotificationsModule.forRoot(),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    AuthModule,
    BranchModule,
    DashboardModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    Title       
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
