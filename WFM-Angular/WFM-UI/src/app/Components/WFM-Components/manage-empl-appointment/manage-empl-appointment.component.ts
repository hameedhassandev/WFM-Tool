import { Component, OnInit } from '@angular/core';
import { EmployeeAppointmentService } from 'src/app/Services/employee-appointment.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { WFMService } from 'src/app/Services/wfm.service';

@Component({
  selector: 'app-manage-empl-appointment',
  templateUrl: './manage-empl-appointment.component.html',
  styleUrls: ['./manage-empl-appointment.component.css']
})
export class ManageEmplAppointmentComponent implements OnInit {
  allEmpWithDep:any
  searchText:any
  allAppointment:any
  employee:any
  noAppointment = false
  constructor(private _wfmService : WFMService,
    private _appointmentServ : EmployeeAppointmentService, private _empService:EmployeeService) {
  }
  ngOnInit(): void {
    this.getAllEmployeeWithDepartment()
  }

  

getAllEmployeeWithDepartment(){
  this._wfmService.GetAllDepartmentsWithEmployees().subscribe({
    next:(res)=>{
      this.allEmpWithDep = res  
      console.log(this.allEmpWithDep)
    },
    error:(err)=>{
      console.log(err)
    }
  })
}

getEmployeeData(empId:string){
  this.noAppointment = false
  this._appointmentServ.getAllEmployeeApointments(empId).subscribe({
    next:(res)=>{
      this.allAppointment = res  
      if(this.allAppointment.length === 0){
        this.noAppointment = true
        console.log('data appo: ' +this.noAppointment)
      }
      console.log(this.allAppointment)
      this.getEmployeeById(empId);

    },
    error:(err)=>{
      console.log(err)
    }
  })}

  getEmployeeById(empId:string){
    this._empService.getEmpById(empId).subscribe({
      next:(res)=>{
        this.employee = res  
        console.log(this.employee)
      },
      error:(err)=>{
        console.log(err)
      }
    })}


  addNewAppointment(employeePid:string){
    alert('employeePid = ' + employeePid)
  }



}