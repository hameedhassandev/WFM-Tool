import { Time } from "@angular/common";

export interface Breaks{
     id: number,
     employeeAppointmentId: string,
     from: Time,
     to: Time
}