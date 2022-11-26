import { Material } from "../../material/model/material";
import { Shipment } from "../../shipment/model/shipment";

export interface InventoryReceivingVoucherDetail{
    materialId:string;
    material: Material;
    shipmentId:string;
    shipment:Shipment;
    quantityReceiving:string;
    damagedQuantity:string;
    price:string;
    amount: string;
    warehouseShelveId:string;
    priceTotalItem:number;
}