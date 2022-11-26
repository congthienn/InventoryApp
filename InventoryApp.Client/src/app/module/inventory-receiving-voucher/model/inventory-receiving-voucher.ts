import { Branch } from "../../branch/model/branch";
import { Order } from "../../order/model/order";
import { Warehouse } from "../../warehouse/model/warehouse";
import { InventoryReceivingVoucherDetail } from "./inventory-receiving-voucher-detail";

export interface InventoryReceivingVoucher{
    code:string;
    supplierOrderId:string;
    supplierOrder:Order;
    branchRequestId:string;
    branchRequest:Branch;
    warehouseId:string;
    warehouse:Warehouse;
    userReceiveId:string;
    goodsImportDate:string;
    detail: InventoryReceivingVoucherDetail[];
}