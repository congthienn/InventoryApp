import { Material } from "../../material/model/material";
import { Shipment } from "../../shipment/model/shipment";

export interface InventoryDeliveryVoucherDetail{
    materialId:string;
    material: Material;
    shipmentId:string;
    shipment:Shipment;
    quantityDelivery:string;
    price:string;
    amount: string;
    priceTotalItem:number;
}