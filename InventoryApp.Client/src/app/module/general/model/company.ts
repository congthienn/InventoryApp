import { District } from "../../province/model/district";
import { Province } from "../../province/model/province";
import { Ward } from "../../province/model/ward";

export interface Company{
    id:string,
    code: string;
    companyName: string;
    email: string;
    phoneNumber: string;
    fax: string;
    taxCode: string;
    provinceId:string;
    province:Province;
    districtId:string;
    district:District;
    wardId:string;
    ward:Ward;
    address:string;
}