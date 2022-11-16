import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipmentComponent } from './shipment.component';

export const routes: Routes = [
  {path: '', redirectTo:'lo-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: ShipmentComponent}]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShipmentRoutingModule { }
