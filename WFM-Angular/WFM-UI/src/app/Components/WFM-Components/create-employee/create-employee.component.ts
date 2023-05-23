import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { AddAppointmentFormComponent } from '../add-appointment-form/add-appointment-form.component';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {
createEmployee!: FormGroup
selectValurError = false
 departments:any
 roles:any
 responseMsg:any
  constructor(private _departmentService:DepartmentService,
     private _empService:EmployeeService, private _fb:FormBuilder,public _dialog: MatDialog) {
    
  }
  ngOnInit(): void {
    this.AllDepartments();
    this.AllRoles();

    this.createEmployee = this._fb.group({
      fullName : ['', Validators.required],
      userName : ['', Validators.required],
      phoneNo : ['', Validators.required],
      password : ['', Validators.required],
      roleName : ['',Validators.required],
      departmentId : ['',Validators.required],
       
    })
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


  validateSelectList(value:any){
    if(value === ""){
      this.selectValurError = true;
   }else{
    this.selectValurError = false;
   }
  }

  addEmployee(){
    var fData = new FormData();
    fData.append('FullName',this.createEmployee.get('fullName')?.value);
    fData.append('UserName',this.createEmployee.get('userName')?.value);
    fData.append('PhoneNo',this.createEmployee.get('phoneNo')?.value);
    fData.append('Password',this.createEmployee.get('password')?.value);
    fData.append('RoleName',this.createEmployee.get('roleName')?.value);
    fData.append('DepartmentId',this.createEmployee.get('departmentId')?.value);
    if(this.createEmployee.valid){
      this._empService.createEmployee(fData).subscribe({
        next:(res)=>{
            this.responseMsg = 'New Employee Created Successfully';
            console.log(res)
    
          },error: err=>{
            this.responseMsg = 'Somthing error: '+ err.error;
  
            console.log(err);}
       });
    }}



    
}
