import { Branch } from "../../branch/model/branch";
import { Supplier } from "../../business-partner/supplier/model/supplier";
import { OrderDetail } from "./order-detail";

export interface Order{
    code:string;
    status:string;
    supplierId:string;
    supplier: Supplier;
    orderDate: Date;
    branchRequestId: string;
    branchRequest: Branch;
    supplierOrderDetail: OrderDetail[];
    priceTotal:string;
    employeeName:string;
}