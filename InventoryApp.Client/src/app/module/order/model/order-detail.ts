import { Material } from "../../material/model/material";

export interface OrderDetail{
    materialId: string;
    material: Material;
    materialPrice:string;
    quantityRequest:number;
    priceTotalItem:number;
}