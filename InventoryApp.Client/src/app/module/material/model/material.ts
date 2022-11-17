import { CategoryMaterial } from "../../category-material/model/category-material";
import { Trademark } from "../../trademark/model/trademark";

export interface Material{
    id:string;
    name :string;
    code: string;
    salePrice :string;
    costPrice:string;
    baseMaterialUnit :string;
    categoryMaterialId :string;
    categoryMaterial: CategoryMaterial;
    trademarkId :string;
    trademark : Trademark;
    minimumInventory :string;
    maximumInventory :string;
    weight :string;
    detailedDescription :string;
    stopBusiness:boolean;
}