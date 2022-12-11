import { Branch } from "../../branch/model/branch";
import { Customer } from "../../business-partner/customer/model/customer";
import { DeliveryCompany } from "../../business-partner/delivery-company/model/delivery-company";
import { CustomerOrderDetail } from "./customer-order-detail";
import { ReturnedMaterial } from "./returned-material";

export interface CustomerOrder{
    code:string;
    id:string;
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
    returnedMaterial:ReturnedMaterial;
    provinceId:string;
    districtId:string;
    wardId:string;
    address: string;
    deliveryAddress:string;
    employeeName:string;
    deliveryCompanyId:string;
    deliveryCompany:DeliveryCompany;
}