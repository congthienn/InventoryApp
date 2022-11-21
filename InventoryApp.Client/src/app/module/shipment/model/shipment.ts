import { Branch } from "../../branch/model/branch";

export interface Shipment{
    id:string;
    code:string;
    expirationDate:string;
    branchId:string;
    branch:Branch;
}