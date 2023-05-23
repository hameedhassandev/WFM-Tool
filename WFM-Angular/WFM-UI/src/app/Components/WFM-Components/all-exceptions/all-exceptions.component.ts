import { Component, OnInit } from '@angular/core';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';

@Component({
  selector: 'app-all-exceptions',
  templateUrl: './all-exceptions.component.html',
  styleUrls: ['./all-exceptions.component.css']
})
export class AllExceptionsComponent implements OnInit{
 allEmpExceptions:any
 isEmpty = false
 filterMsg : any
 exceptionsTypes:any
 exceptionStatus:any
  constructor(private _empExcepService:EmployeeExceptionsService) {
    
  }
  ngOnInit(): void {
    this.AllEmployeeException();
    this.ExceptionTypes();
    this.ExceptionStatus();
  }

  AllEmployeeException(){
    this._empExcepService.getAllEmployeeException().subscribe({
      next:(res)=>{
        this.allEmpExceptions = res  
        if(this.allEmpExceptions.length === 0){
          this.isEmpty  =true
          this.filterMsg = "No exceptions found!"
        }
        console.log(this.allEmpExceptions)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }


  ExceptionTypes(){
    this._empExcepService.getAllExceptionTypes().subscribe({
      next:(res)=>{
        this.exceptionsTypes = res  
        console.log(this.exceptionsTypes)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  ExceptionStatus(){
    this._empExcepService.getAllExceptionStatus().subscribe({
      next:(res)=>{
        this.exceptionStatus = res  
        console.log(this.exceptionStatus)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
}
