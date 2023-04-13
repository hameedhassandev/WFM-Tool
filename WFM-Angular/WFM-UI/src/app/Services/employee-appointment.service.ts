import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeAppointment } from '../Interfaces/EmployeeAppointment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeAppointmentService {

  private appointmentAPI: string = environment.WFMAPIURL + "/EmployeeAppointment";

  constructor(private _http : HttpClient) { }


  getAllEmployeeApointments(employeeId:string):Observable<EmployeeAppointment[]>{
    return this._http.get<EmployeeAppointment[]>(`${this.appointmentAPI}/EmployeeAppointments?EmployeePID=${employeeId}`);
  }

  getAllEmployeeApointmentsPaging(employeeId:string,take?:number,skip?:number):Observable<EmployeeAppointment[]>{
    return this._http.get<EmployeeAppointment[]>(`${this.appointmentAPI}/EmployeeAppointmentsPaging?EmployeePID=${employeeId}&take=${take}&skip=${skip}`);
  }


}
