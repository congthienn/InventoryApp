import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './auth/login/login.component';
import { LoginGuard } from './auth/login/login.guard';
import { AdminLayoutComponent } from './share/admin-layout/admin-layout.component';
import { ErrorComponent } from './share/layout/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: '/tong-quan', pathMatch: 'full' },
  { path:'chi-nhanh', redirectTo: '/chi-nhanh/danh-sach', pathMatch: 'full'},
  { path: '', component: AdminLayoutComponent, canActivate: [AuthGuard],
    children:[
      {path:'tong-quan', loadChildren: () => import('./module/dashboard/dashboard.module').then(m => m.DashboardModule) },
      {path:'chi-nhanh', loadChildren: () => import('./module/branch/branch.module').then(m => m.BranchModule) }
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
