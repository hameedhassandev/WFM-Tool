import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DepartmentWithEmp } from '../Interfaces/DepartmentWithEmp';
import { typeOfDay } from '../Interfaces/TypeOfDay';

@Injectable({
  providedIn: 'root'
})
export class WFMService {
  private wfm: string = environment.WFMAPIURL + "/WFM";

  constructor(private _http : HttpClient) { }


  GetAllDepartmentsWithEmployees():Observable<DepartmentWithEmp[]>{

    return this._http.get<DepartmentWithEmp[]>(`${this.wfm}/GetAllDepartmentsWithEmployees`);

  }

  GetAllTypesOfDay():Observable<typeOfDay[]>{
    return this._http.get<typeOfDay[]>(`${this.wfm}/GetTypeOfDays`);

  }


  
}
