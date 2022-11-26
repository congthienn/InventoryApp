import { Branch } from "../../branch/model/branch";
import { Supplier } from "../../business-partner/supplier/model/supplier";
import { Order } from "../../order/model/order";
import { Warehouse } from "../../warehouse/model/warehouse";
import { InventoryReceivingVoucherDetail } from "./inventory-receiving-voucher-detail";

export interface InventoryReceivingVoucher{
    id:string;
    code:string;
    supplierOrderId:string;
    supplierOrder:Order;
    supplier: Supplier;
    branchRequestId:string;
    branchRequest:Branch;
    warehouseId:string;
    warehouse:Warehouse;
    userReceiveId:string;
    userReceiveName:string;
    goodsImportDate:string;
    detail: InventoryReceivingVoucherDetail[];
}