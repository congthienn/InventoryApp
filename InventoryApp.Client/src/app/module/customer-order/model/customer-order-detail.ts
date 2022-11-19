import { Material } from "../../material/model/material";

export interface CustomerOrderDetail{
    materialId: string;
    material: Material;
    materialPrice:string;
    quantityRequest:number;
    priceTotalItem:number;
}