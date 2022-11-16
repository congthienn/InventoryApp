import { District } from "src/app/module/province/model/district";
import { Province } from "src/app/module/province/model/province";
import { Ward } from "src/app/module/province/model/ward";
import { SupplierGroup } from "./supplierGroup";

export interface Supplier{
    id:string;
    supplierName: string;
    email: string;
    code: string;
    phoneNumber: string;
    fax: string;
    taxCode: string;
    address: string;
    provinceId: string;
    province: Province;
    districtId: string;
    district: District;
    wardId: string;
    ward: Ward;
    supplierGroupId:string;
    supplierGroup : SupplierGroup;
    status:boolean;
  }