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
  { path: '', component: AdminLayoutComponent, canActivate: [AuthGuard],
    children:[
      {path:'tong-quan', loadChildren: () => import('./module/dashboard/dashboard.module').then(m => m.DashboardModule) },
      {path:'chi-nhanh', loadChildren: () => import('./module/branch/branch.module').then(m => m.BranchModule) },
      {path:'khach-hang', loadChildren: () => import('./module/business-partner/customer/customer.module').then(m => m.CustomerModule) },
      {path:'nha-cung-cap', loadChildren: () => import('./module/business-partner/supplier/supplier.module').then(m => m.SupplierModule) },
      {path:'lo-hang', loadChildren: () => import('./module/shipment/shipment.module').then(m => m.ShipmentModule) },
      {path:'san-pham', loadChildren: () => import('./module/material/material.module').then(m => m.MaterialModule) }
    ]
  },
  { path:"login", component: LoginComponent, canActivate:[LoginGuard] },
  { path: '**', component: ErrorComponent }, 
];  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
