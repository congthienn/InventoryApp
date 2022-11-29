import { Branch } from "../../branch/model/branch";
import { District } from "../../province/model/district";
import { Province } from "../../province/model/province";
import { Ward } from "../../province/model/ward";

export interface Employee{
    id:string;
    name: string;
    code:string;
    sex:boolean;
    email:string;
    identityCard:string;
    birthday:string
    phoneNumber:string
    address:string
    branchId:string
    branch:Branch
    provinceId:string
    province:Province;
    districtId:string
    district:District
    wardId:string;
    ward:Ward;
    cardImage:string;
}