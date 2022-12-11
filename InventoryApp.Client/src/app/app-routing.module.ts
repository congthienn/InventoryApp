import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './auth/login/login.component';
import { LoginGuard } from './auth/login/login.guard';
import { AdminLayoutComponent } from './share/admin-layout/admin-layout.component';
import { ErrorComponent } from './share/layout/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: '/tong-quan', pathMatch: 'full' },
  { path:'chi-nhanh/', redirectTo: 'chi-nhanh', pathMatch: 'full'},
  { path:'lo-hang/', redirectTo: 'lo-hang', pathMatch: 'full'},
  { path:'san-pham/', redirectTo: 'san-pham', pathMatch: 'full'},
  { path:'kho-hang/', redirectTo: 'kho-hang', pathMatch: 'full'},
  { path:'dat-hang/', redirectTo: 'dat-hang', pathMatch: 'full'},
  { path:'don-hang/', redirectTo: 'don-hang', pathMatch: 'full'},
  { path:'nhan-vien/', redirectTo: 'nhan-vien', pathMatch: 'full'},
  { path:'cai-dat-chung', redirectTo: 'cai-dat-chung/thong-tin-cong-ty', pathMatch: 'full'},
  { path: '', component: AdminLayoutComponent, canActivate: [AuthGuard],
    children:[
      {path:'tong-quan', loadChildren: () => import('./module/dashboard/dashboard.module').then(m => m.DashboardModule) },
      {path:'chi-nhanh', loadChildren: () => import('./module/branch/branch.module').then(m => m.BranchModule) },
      {path:'khach-hang', loadChildren: () => import('./module/business-partner/customer/customer.module').then(m => m.CustomerModule) },
      {path:'nha-cung-cap', loadChildren: () => import('./module/business-partner/supplier/supplier.module').then(m => m.SupplierModule) },
      {path:'lo-hang', loadChildren: () => import('./module/shipment/shipment.module').then(m => m.ShipmentModule) },
      {path:'san-pham', loadChildren: () => import('./module/material/material.module').then(m => m.MaterialModule) },
      {path:'kho-hang', loadChildren: () => import('./module/warehouse/warehouse.module').then(m => m.WarehouseModule) },
      {path:'dat-hang', loadChildren: () => import('./module/order/order.module').then(m => m.OrderModule) },
      {path:'don-hang', loadChildren: () => import('./module/customer-order/customer-order.module').then(m => m.CustomerOrderModule) },
      {path:'nhan-vien', loadChildren: () => import('./module/user/user.module').then(m => m.UserModule) },
      {path:'cai-dat-chung', loadChildren: () => import('./module/general/general.module').then(m => m.GeneralModule) }
    ]
  },
  { path:"login", component: LoginComponent, canActivate:[LoginGuard] },
  { path: '**', component: ErrorComponent }, 
  { path: 'error', component: ErrorComponent }, 
];  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
