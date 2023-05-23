import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-exception-action',
  templateUrl: './exception-action.component.html',
  styleUrls: ['./exception-action.component.css']
})
export class ExceptionActionComponent implements OnInit{
  actionForm!:FormGroup
  employeeId:any
  exceptionId:any
  excepDetails:any
  masg:any
  exceptionStatus = [
    {id:1,name:'Approved'},
    {id:2,name:'Rejected'},
  ]
  constructor(private _excepService: EmployeeExceptionsService, 
    private _fb:FormBuilder,private _activatedroute:ActivatedRoute,private _employeeServ:EmployeeService) {
  }
  ngOnInit(): void {
//empId/:excId
   this.employeeId =this._activatedroute.snapshot.paramMap.get("empId");
   this.exceptionId =this._activatedroute.snapshot.paramMap.get("excId");

   
   this.getExceptionById(this.exceptionId,this.employeeId)
    this.actionForm = this._fb.group({
      comment : [''],
    })



  }

  getExceptionById(excId:any,empId:any){
    this._excepService.getAllExceptionByExcId(excId,empId).subscribe({
      next:(res)=>{
        this.excepDetails = res  
        console.log(this.excepDetails)
      },
      error:(err)=>{
        alert("Exception not found")
        console.log(err)
      }
    })
  }


  checkStatus(e:any){
      let status = e.target.value
      
      if(status === '')
        this.masg = 'Status is required'
      else if(status === '1'){
          this.ApproveException();
      }else if(status === '2'){
        this.RejectException()
      }
  }

  ApproveException(comment?:string){
    alert('approved')
  }

  RejectException(comment?:string){
    alert('rejected')

  }




}
