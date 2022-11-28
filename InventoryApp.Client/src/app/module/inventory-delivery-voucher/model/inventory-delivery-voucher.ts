import { Branch } from "../../branch/model/branch";
import { Customer } from "../../business-partner/customer/model/customer";
import { CustomerOrder } from "../../customer-order/model/customer-order";
import { Order } from "../../order/model/order";
import { User } from "../../user/model/user";
import { Warehouse } from "../../warehouse/model/warehouse";
import { InventoryDeliveryVoucherDetail } from "./inventory-delivery-voucher-detail";

export interface InventoryDeliveryVoucher{
    id:string;
    code:string;
    orderId:string;
    order:CustomerOrder;
    branchId:string;
    branch:Branch;
    warehouseId:string;
    warehouse:Warehouse;
    userDeliveryId:string;
    userDelivery:User;
    goodsIssueDate:string;
    customer: Customer;
    details: InventoryDeliveryVoucherDetail[];
}