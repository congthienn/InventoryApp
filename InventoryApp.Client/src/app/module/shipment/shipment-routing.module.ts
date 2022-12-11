import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { ShipmentComponent } from './shipment.component';

export const routes: Routes = [
  {path: '', redirectTo:'lo-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: ShipmentComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShipmentRoutingModule { }
