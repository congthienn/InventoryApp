import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from 'src/app/auth/role.guard';
import { AddInventoryDeliveryVoucherComponent } from '../inventory-delivery-voucher/add-inventory-delivery-voucher/add-inventory-delivery-voucher.component';
import { InventoryDeliveryVoucherListComponent } from '../inventory-delivery-voucher/inventory-delivery-voucher-list/inventory-delivery-voucher-list.component';
import { AddInventoryReceivingVoucherComponent } from '../inventory-receiving-voucher/add-inventory-receiving-voucher/add-inventory-receiving-voucher.component';
import { InventoryReceivingVoucherListComponent } from '../inventory-receiving-voucher/inventory-receiving-voucher-list/inventory-receiving-voucher-list.component';
import { WarehouseLayoutComponent } from '../warehouse-layout/warehouse-layout.component';
import { AddWarehouseComponent } from './add-warehouse/add-warehouse.component';
import { ProductStatisticsComponent } from './product-statistics/product-statistics.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';

export const routes: Routes = [
  {path: '', redirectTo:'kho-hang', pathMatch:'full'},
  { path: '', children: [ {path: '', component: WarehouseListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]}, 
  { path: '', children: [ {path: 'them-moi', component: AddWarehouseComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống"}}]},
  { path: '', children: [ {path: 'danh-sach-phieu-nhap-kho', component: InventoryReceivingVoucherListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
  { path: '', children: [ {path: 'danh-sach-phieu-xuat-kho', component: InventoryDeliveryVoucherListComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
  { path: '', children: [ {path: 'nhap-kho', component: AddInventoryReceivingVoucherComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
  { path: '', children: [ {path: 'xuat-kho', component: AddInventoryDeliveryVoucherComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
  { path: '', children: [ {path: 'bo-cuc-kho', component: WarehouseLayoutComponent, canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
  { path: '', children: [ {path: 'thong-ke-san-pham', component: ProductStatisticsComponent,canActivate:[RoleGuard], data:{role: "Quản trị hệ thống,Thủ kho"}}]},
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
