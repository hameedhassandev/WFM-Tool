import { Time } from "@angular/common";
import { User } from "./User";
import { ExceptionStatus } from "./ExceptionStatus";
import { ExceptionType } from "./ExceptionType";
import { ExceComment } from "./ExceComment";

export interface Excption{
    id:number,
    creatorPID:string,
    approvedByPID:string,
    user:User,
    manager:User,
    exceptionDate:Date,
    from:Time,
    to:Time,
    exceptionStatus:ExceptionStatus,
    exceptionType:ExceptionType,
    exceptionComments:ExceComment[]|null
    


}