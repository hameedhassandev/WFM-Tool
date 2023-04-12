import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Department } from '../Interfaces/Department';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private department: string = environment.WFMAPIURL + "/Department";
  constructor(private _http : HttpClient) { }


  
  getAllDepartments():Observable<Department[]>{
    return this._http.get<Department[]>(`${this.department}/GetAll`);
  }
}
