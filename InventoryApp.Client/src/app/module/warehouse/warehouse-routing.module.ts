import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddInventoryReceivingVoucherComponent } from '../inventory-receiving-voucher/add-inventory-receiving-voucher/add-inventory-receiving-voucher.component';
import { InventoryReceivingVoucherListComponent } from '../inventory-receiving-voucher/inventory-receiving-voucher-list/inventory-receiving-voucher-list.component';
import { AddWarehouseComponent } from './add-warehouse/add-warehouse.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'kho-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: WarehouseListComponent}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddWarehouseComponent}]},
  { path: '', children: [ {path: 'danh-sach-phieu-nhap-kho', component: InventoryReceivingVoucherListComponent}]},
  { path: '', children: [ {path: 'nhap-kho', component: AddInventoryReceivingVoucherComponent}]},
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
