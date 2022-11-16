import { Branch } from "src/app/module/branch/model/branch";
import { District } from "src/app/module/province/model/district";
import { Province } from "src/app/module/province/model/province";
import { Ward } from "src/app/module/province/model/ward";
import { CustomerGroup } from "./customerGroup";

export interface Customer{
  id:string;
  customerName: string;
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
  customerGroupId:string;
  customerGroup : CustomerGroup;
  branchId:string;
  branch: Branch;
}