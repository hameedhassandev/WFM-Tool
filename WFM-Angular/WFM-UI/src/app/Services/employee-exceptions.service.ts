import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Excption } from '../Interfaces/Excption';
import { Observable } from 'rxjs';
import { ExceptionType } from '../Interfaces/ExceptionType';

@Injectable({
  providedIn: 'root'
})
export class EmployeeExceptionsService {

  private exceptions: string = environment.WFMAPIURL + "/EmployeeException";

  constructor(private _http : HttpClient) { }


  getAllExceptions(employeeId:string):Observable<Excption[]>{
    return this._http.get<Excption[]>(`${this.exceptions}/GetAllEmpExceptoins?employeePID=${employeeId}`);
  }


  getAllExceptionTypes():Observable<ExceptionType[]>{
    return this._http.get<ExceptionType[]>(`${this.exceptions}/GetExceptonTypes`);

  }

  createException(data:FormData){
    return this._http.post<any>(`${this.exceptions}/CreateException`,data)

  }

}
