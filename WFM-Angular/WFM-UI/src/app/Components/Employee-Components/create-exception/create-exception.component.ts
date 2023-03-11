import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-create-exception',
  templateUrl: './create-exception.component.html',
  styleUrls: ['./create-exception.component.css']
})
export class CreateExceptionComponent implements OnInit{
teamLeaders:any
exceptionType :any
createExceptionForm !:FormGroup
selectValurError = false
responMassage:any

  constructor(private _employeeService:EmployeeService,private _employeeExcService:EmployeeExceptionsService
    , private _fb :FormBuilder) {
    
  }
  ngOnInit(): void {
    this.getAllTeamLeaders();
    this.getAllExceptionTypes();

    this.createExceptionForm = this._fb.group({
      exceptionTypeId : ['', Validators.required],
      approvedByPID: ['', Validators.required],
      exceptionDate: ['', Validators.required],
      from: ['', Validators.required],
      to: ['', Validators.required],
      exceptionComment: [''],
    })
  }

  getAllTeamLeaders(){
    this._employeeService.getAllTeamLeaders().subscribe(tl=>{
      this.teamLeaders = tl;
      console.log(this.teamLeaders);
    })
  }

  getAllExceptionTypes(){
    this._employeeExcService.getAllExceptionTypes().subscribe(exc=>{
      this.exceptionType = exc;
      console.log(this.exceptionType);
    })
  }
  
  getExceptionType(event:any){
    console.log(event.target.value);
  }

  validateSelectList(value:any){
    if(value === ""){
      this.selectValurError = true;
   }else{
    this.selectValurError = false;
   }
  }

  createEception(){
    let creatorPID = "6403e590-a212-4b2a-9ada-b8f03b90b25f";
    var fData = new FormData();
    fData.append('ExceptionTypeId',this.createExceptionForm.get('exceptionTypeId')?.value);
    fData.append('CreatorPID', creatorPID);
    fData.append('ApprovedByPID',this.createExceptionForm.get('approvedByPID')?.value);
    fData.append('ExceptionDate',this.createExceptionForm.get('exceptionDate')?.value);
    fData.append('From',this.createExceptionForm.get('from')?.value);
    fData.append('To',this.createExceptionForm.get('to')?.value);
    fData.append('ExceptionComment',this.createExceptionForm.get('exceptionComment')?.value);
  const data ={
    ExceptionTypeId:this.createExceptionForm.get('exceptionTypeId')?.value,
    CreatorPID:creatorPID,
    ApprovedByPID:this.createExceptionForm.get('approvedByPID')?.value,
    ExceptionDate:this.createExceptionForm.get('exceptionDate')?.value,
    From:this.createExceptionForm.get('from')?.value,
    To:this.createExceptionForm.get('to')?.value,
    ExceptionComment:this.createExceptionForm.get('exceptionComment')?.value,
  }
  console.log(data)

  if(this.createExceptionForm.valid){
    this._employeeExcService.createException(fData).subscribe({
      next:(res)=>{
          this.responMassage = 'Your Exception Created Successfully with Exception Id = '+res.id;
          console.log(res)
  
        },error: err=>{
          this.responMassage = 'Somthing error: '+ err.error;

          console.log(err);}
     });
  }

    //alert("Exception Created successfully");
  }
}  
