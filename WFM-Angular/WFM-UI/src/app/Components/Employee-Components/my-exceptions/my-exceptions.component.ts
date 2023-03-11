import { Component, OnInit } from '@angular/core';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';

@Component({
  selector: 'app-my-exceptions',
  templateUrl: './my-exceptions.component.html',
  styleUrls: ['./my-exceptions.component.css']
})
export class MyExceptionsComponent implements OnInit {
allEmpExceptions:any
empId:string = "6403e590-a212-4b2a-9ada-b8f03b90b25f";
constructor(private _exceptionService:EmployeeExceptionsService) {}

  ngOnInit(): void {
    this.getAllEmplExceptions(this.empId);
  }

  getAllEmplExceptions(employeeId:string){
    this._exceptionService.getAllExceptions(employeeId).subscribe({
      next:(res)=>{
        this.allEmpExceptions = res  
        console.log(this.allEmpExceptions)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

}
