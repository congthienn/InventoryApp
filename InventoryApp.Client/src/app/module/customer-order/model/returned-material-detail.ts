import { Material } from "../../material/model/material";
import { ReturnedMaterial } from "./returned-material";

export interface ReturnedMaterialDetail{
    returnedMaterialId:string;
    returnedMaterial: ReturnedMaterial
    materialId:string;
    material: Material;
    quantity:string;
    price:string;
    quantityInOrder:string;
    priceTotalItem:number;
}