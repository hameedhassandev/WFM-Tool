import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../Interfaces/User';
import { Observable } from 'rxjs';
import { Role } from '../Interfaces/Role';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employee: string = environment.WFMAPIURL + "/Emolyee";

  constructor(private _http : HttpClient) { }


  getAllRoles():Observable<Role[]>{

    return this._http.get<Role[]>(`${this.employee}/GetAllRoles`);

  }
  
  getAllTeamLeaders():Observable<User[]>{
    return this._http.get<User[]>(`${this.employee}/GetAllTeamLeaders`);
  }

  getEmpById(empId:string):Observable<User>{
    return this._http.get<User>(`${this.employee}/GetEmployeeById?employeeId=${empId}`);
  }

}
