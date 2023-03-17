import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';

@Component({
  selector: 'app-employees-exceptions',
  templateUrl: './employees-exceptions.component.html',
  styleUrls: ['./employees-exceptions.component.css']
})
export class EmployeesExceptionsComponent implements OnInit{

  filterForm !:FormGroup
  filterDateVal :any
  employeeExceptions: any
  isEmpty = false
  filterMsg : any
  tlId:string = "2a61579e-996b-4f25-a79e-b79aa9b4acb5";


  constructor(private _fb:FormBuilder,private _emploExcepService:EmployeeExceptionsService) {    
  }
  ngOnInit(): void {
    this.filterForm = this._fb.group({
      filterDate : ['', Validators.required],
    })
    this.getAllEmpExceptionForTl(this.tlId);
  }

  getAllEmpExceptionForTl(tlId:string){
    this._emploExcepService.getAllExceptionsForTl(tlId).subscribe({
      next:(res)=>{
        this.employeeExceptions = res  
        console.log(this.employeeExceptions)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
  filterByDate(){
    this.isEmpty = false
    this.filterDateVal =  this.filterForm.get('filterDate')?.value
    console.log(this.filterDateVal)
    this._emploExcepService.getAllExceptionsForTlByFilter(this.tlId,this.filterDateVal).subscribe({
      next:(res)=>{
        this.employeeExceptions = res  
        if(this.employeeExceptions.length === 0){
          this.isEmpty  =true
          this.filterMsg = "No exceptions found with this date"
        }
        console.log(this.employeeExceptions)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  clearFilter(){
    this.isEmpty = false
    this.filterForm.reset()
    this.getAllEmpExceptionForTl(this.tlId);
  }


}
