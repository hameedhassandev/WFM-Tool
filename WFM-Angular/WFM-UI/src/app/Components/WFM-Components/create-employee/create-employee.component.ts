import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {

 departments:any
 roles:any
  constructor(private _departmentService:DepartmentService, private _empService:EmployeeService) {
    
  }
  ngOnInit(): void {
    this.AllDepartments();
    this.AllRoles();
  }


  AllDepartments(){
    this._departmentService.getAllDepartments().subscribe({
      next:(res)=>{
        this.departments = res  
        console.log(this.departments)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  AllRoles(){
    this._empService.getAllRoles().subscribe({
      next:(res)=>{
        this.roles = res  
        console.log(this.roles)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

}
