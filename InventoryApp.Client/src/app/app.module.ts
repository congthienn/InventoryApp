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
import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';
import { SupplierModule } from './module/business-partner/supplier/supplier.module';
import { CustomerModule } from './module/business-partner/customer/customer.module';
import { ShipmentModule } from './module/shipment/shipment.module';
import { MaterialModule } from './module/material/material.module';
import { QuillModule } from 'ngx-quill';
import { TrademarkModule } from './module/trademark/trademark.module';
import { CategoryMaterialModule } from './module/category-material/category-material.module';
import { WarehouseModule } from './module/warehouse/warehouse.module';
import { OrderModule } from './module/order/order.module';
import { CustomerOrderModule } from './module/customer-order/customer-order.module';
import { UserModule } from './module/user/user.module';
import { RoleModule } from './module/role/role.module';
import { WarehouseLayoutModule } from './module/warehouse-layout/warehouse-layout.module';
import { GeneralModule } from './module/general/general.module';


@NgModule({ 
  declarations: [
    AppComponent,
    AdminLayoutComponent
  ],
  imports: [
    AgGridModule,
    QuillModule.forRoot(),
    SimpleNotificationsModule.forRoot(),
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    AuthModule,
    BranchModule,
    DashboardModule,
    CustomerModule,
    SupplierModule,
    ShipmentModule,
    MaterialModule,
    TrademarkModule,
    CategoryMaterialModule,
    WarehouseModule,
    OrderModule,
    CustomerOrderModule,
    UserModule,
    RoleModule,
    WarehouseLayoutModule,
    GeneralModule
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
