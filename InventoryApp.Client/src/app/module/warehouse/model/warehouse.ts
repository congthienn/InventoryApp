import { Branch } from "../../branch/model/branch";

export interface Warehouse{
    id:string;
    code:string;
    name: string;
    branchId: string;
    branch: Branch;
    maximumCapacity:number;
    blank:number;
}