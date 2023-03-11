import { Time } from "@angular/common";
import { typeOfDay } from "./TypeOfDay";
import { Breaks } from "./Breaks";
import { Excption } from "./Excption";

export interface EmployeeAppointment{
        id:number,
        employeePID:string,
        typeOfDayId:number,
        appointMentDate:Date,
        from:Time,
        to:Time,
        typeOfDay:typeOfDay,
        breaks:Breaks[] | null,
        exceptions:Excption[]| null
}