import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeAppointmentService } from 'src/app/Services/employee-appointment.service';

@Component({
  selector: 'app-scheduale-details',
  templateUrl: './scheduale-details.component.html',
  styleUrls: ['./scheduale-details.component.css']
})
export class SchedualeDetailsComponent implements OnInit {

  appointment:any
  constructor( private _dialog: MatDialogRef<SchedualeDetailsComponent>,
     @Inject(MAT_DIALOG_DATA) public details:any, private _appointmentServ:EmployeeAppointmentService) {    
  }

  ngOnInit(): void {
    const employeeId = this.details.EmployeeId
    const appointmentId = this.details.Id
    this.AppointmentDetails(employeeId,appointmentId);
    console.log(this.details.Id)
}

AppointmentDetails(employeeId:string, id:number){
  this._appointmentServ.getApointmentDetails(employeeId,id).subscribe({
    next:(res)=>{
      this.appointment = res  
      console.log(this.appointment)
    },
    error:(err)=>{
      console.log(err)
    }
  })
}

}
