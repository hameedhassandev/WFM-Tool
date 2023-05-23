import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeExceptionsService } from 'src/app/Services/employee-exceptions.service';

@Component({
  selector: 'app-find-ordispute-exception',
  templateUrl: './find-ordispute-exception.component.html',
  styleUrls: ['./find-ordispute-exception.component.css']
})
export class FindOrdisputeExceptionComponent implements OnInit {

  excepDetails:any
  findForm !:FormGroup
  changeExcForm!:FormGroup
  exceptionId:any
  empId:any
  creatorName:any
  comment:any
  constructor(private _excepService: EmployeeExceptionsService, private _fb:FormBuilder) {
    
  }
  ngOnInit(): void {
    this.findForm = this._fb.group({
      exceptionTypeId : ['', Validators.required],
    })

    this.changeExcForm = this._fb.group({
      comment: ['']
    })

   // this.getExceptionById(3,"6403e590-a212-4b2a-9ada-b8f03b90b25f");
  }


  show(){ 
      this.exceptionId = this.findForm.get('exceptionTypeId')?.value;
      this.empId = "6403e590-a212-4b2a-9ada-b8f03b90b25f";   
      this.getExceptionById(this.exceptionId,this.empId);
  }

  changeExc(){

    this.empId = "6403e590-a212-4b2a-9ada-b8f03b90b25f";   
    this.creatorName = "Ahmed Kamel Mohamed";
    var fData = new FormData();
    fData.append('ExceptionId',this.findForm.get('exceptionTypeId')?.value);
    fData.append('Comment', this.changeExcForm.get('comment')?.value);
    fData.append('CreatorPID', this.empId);
    fData.append('CreatorName', this.creatorName);

    const data = {
      excepId : this.findForm.get('exceptionTypeId')?.value,
      creatorId: this.empId ,
      creatorName: this.creatorName ,
      comment:this.changeExcForm.get('comment')?.value
    }
    console.log(data)
    this.cancelException(fData);
  }

  getExceptionById(exceptionId : number,employeeId:string){
    this._excepService.getAllExceptionByExcId(exceptionId,employeeId).subscribe({
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

  cancelException(data:FormData){
    this._excepService.cancelException(data).subscribe({
      next:(res)=>{
        this.excepDetails = res  
        this.getExceptionById(this.excepDetails.id,this.excepDetails.creatorPID)
      },
      error:(err)=>{
        alert("Exception not cancelled")
        console.log(err)
      }
    })
  }
}
