import { Branch } from "../../branch/model/branch";
import { Role } from "./role";

export interface User{
    id:string;
    userName:string;
    email: string;
    phoneNumber: string;
    status:boolean;
    role:Role;
    roleId:string
    branchId:string[];
    branch: Branch[];
}