import { Branch } from "src/app/module/branch/model/branch";
import { District } from "src/app/module/province/model/district";
import { Province } from "src/app/module/province/model/province";
import { Ward } from "src/app/module/province/model/ward";

export interface DeliveryCompany{
  id:string;
  name: string;
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
  branchId:string;
  branch: Branch;
}