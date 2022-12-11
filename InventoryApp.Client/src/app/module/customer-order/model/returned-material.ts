import { Order } from "../../order/model/order";
import { ReturnedMaterialDetail } from "./returned-material-detail";

export interface ReturnedMaterial{
    orderId:string;
    order:Order;
    reason:string;
    detail: ReturnedMaterialDetail[];
    formula:boolean;
}