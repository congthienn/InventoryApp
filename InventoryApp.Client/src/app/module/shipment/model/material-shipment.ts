import { Material } from "../../material/model/material";
import { Shipment } from "./shipment";

export interface MaterialShipment{
    materialId:string;
    material: Material;
    shipmentId:string;
    shipment:Shipment;
    materialQuantity:string;
    quantityInStock:string;
}