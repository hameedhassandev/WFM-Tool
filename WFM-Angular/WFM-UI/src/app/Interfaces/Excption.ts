import { Time } from "@angular/common";
import { User } from "./User";
import { ExceptionStatus } from "./ExceptionStatus";
import { ExceptionType } from "./ExceptionType";

export interface Excption{
    id:number,
    creatorPID:string,
    approvedByPID:string,
    user:User,
    exceptionDate:Date,
    from:Time,
    to:Time,
    exceptionStatus:ExceptionStatus,
    exceptionType:ExceptionType,
    


}