import { User } from "./User";

export interface DepartmentWithEmp{
    id:number,
    name:string,
    employees:User[] | null
}