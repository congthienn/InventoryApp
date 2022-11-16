import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './auth/login/login.component';
import { LoginGuard } from './auth/login/login.guard';
import { AdminLayoutComponent } from './share/admin-layout/admin-layout.component';
import { ErrorComponent } from './share/layout/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: '/tong-quan', pathMatch: 'full' },
  { path:'khach-hang/', redirectTo: 'khach-hang', pathMatch: 'full'},
  { path:'chi-nhanh/', redirectTo: 'chi-nhanh', pathMatch: 'full'},
  { path:'nha-cung-cap/', redirectTo: 'nha-cung-cap', pathMatch: 'full'},
  { path: '', component: AdminLayoutComponent, canActivate: [AuthGuard],
    children:[
      {path:'tong-quan', loadChildren: () => import('./module/dashboard/dashboard.module').then(m => m.DashboardModule) },
      {path:'chi-nhanh', loadChildren: () => import('./module/branch/branch.module').then(m => m.BranchModule) },
      {path:'khach-hang', loadChildren: () => import('./module/business-partner/customer/customer.module').then(m => m.CustomerModule) },
      {path:'nha-cung-cap', loadChildren: () => import('./module/business-partner/supplier/supplier.module').then(m => m.SupplierModule) }
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
