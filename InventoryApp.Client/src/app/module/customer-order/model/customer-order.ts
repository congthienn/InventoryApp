import { Branch } from "../../branch/model/branch";
import { Customer } from "../../business-partner/customer/model/customer";
import { CustomerOrderDetail } from "./customer-order-detail";

export interface CustomerOrder{
    code:string;
    status:string;
    customerId:string;
    customer: Customer;
    orderDate: Date;
    branchId: string;
    branch: Branch;
    orderDetail: CustomerOrderDetail[];
    priceTotal:string;
    prepayment:string;
    paid: boolean;
}