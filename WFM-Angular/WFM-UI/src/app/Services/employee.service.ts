import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../Interfaces/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employee: string = environment.WFMAPIURL + "/Emolyee";

  constructor(private _http : HttpClient) { }


  getAllTeamLeaders():Observable<User[]>{
    return this._http.get<User[]>(`${this.employee}/GetAllTeamLeaders`);
  }

}
