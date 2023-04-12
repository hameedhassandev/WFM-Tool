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

  getAllEmployeeException():Observable<Excption[]>{
    return this._http.get<Excption[]>(`${this.exceptions}/GetAllEmployeeExceptions`);
  }

  getAllExceptionsForTl(teamLeaderId:string):Observable<Excption[]>{
    return this._http.get<Excption[]>(`${this.exceptions}/GetExceptonsForTL?teamLeaderId=${teamLeaderId}`);
  }

  getAllExceptionsForTlByFilter(empId:string,date:Date):Observable<Excption[]>{
    console.log('id:' + empId + ' date: '+ date)
    return this._http.get<Excption[]>(`${this.exceptions}/GetAllEmpExceptoinsByDate?employeePID=${empId}&date=${date}`);
  }

  getAllExceptionTypes():Observable<ExceptionType[]>{
    return this._http.get<ExceptionType[]>(`${this.exceptions}/GetExceptonTypes`);

  }
  getAllExceptionByExcId(exceptionId:number, empPID:string):Observable<ExceptionType>{
    return this._http.get<ExceptionType>(`${this.exceptions}/GetExcepton?exceptionId=${exceptionId}&empPID=${empPID}`);

  }
  createException(data:FormData){
    return this._http.post<any>(`${this.exceptions}/CreateException`,data)

  }

  cancelException(data:any){
    return this._http.put<any>(`${this.exceptions}/CancelException`, data);

  }
   
  disputeException(data:any){ 
    return this._http.put<any>(`${this.exceptions}/DisputeException`, data);
  }

  approvexceptionByTl(data:any){ 
    return this._http.put<any>(`${this.exceptions}/ApproveExceptionByTeamLeader`, data);
  }

  approvexceptionByWFM(data:any){ 
    return this._http.put<any>(`${this.exceptions}/ApproveExceptionByWFM`, data);
  }

  rejectedException(data:any){ 
    return this._http.put<any>(`${this.exceptions}/RejectException`, data);
  }



}
 