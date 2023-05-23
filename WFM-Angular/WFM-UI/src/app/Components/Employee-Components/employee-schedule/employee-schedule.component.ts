import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeAppointmentService } from 'src/app/Services/employee-appointment.service';
import { SchedualeDetailsComponent } from '../scheduale-details/scheduale-details.component';
@Component({
  selector: 'app-employee-schedule',
  templateUrl: './employee-schedule.component.html',
  styleUrls: ['./employee-schedule.component.css']
})
export class EmployeeScheduleComponent implements OnInit {
 
  allAppointment:any
  from = 0;
  to = 24;
  type = 'Annual'
  value = "00:00"
  animal: string = "";
  name: string = "";
  employeeId = "6403e590-a212-4b2a-9ada-b8f03b90b25f";
  totalAppointment = 100;
  constructor(private _appointmentServ : EmployeeAppointmentService,public _dialog: MatDialog) {
    
  }
  ngOnInit(): void {
  
    this.getAllApppontment(this.employeeId,3,0);
  }

  getValue(event:any){
    console.log(event.target.value);
  }

 
  getAllApppontment(employeeId:string,take:number,skip:number){
    this._appointmentServ.getAllEmployeeApointmentsPaging(employeeId,take ,skip).subscribe({
      // this._appointmentServ.getAllEmployeeApointmentsPaging(employeeId,100,7).subscribe({
      next:(res)=>{
        this.allAppointment = res  
        console.log(this.allAppointment)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  nextWeek(){
    this.getAllApppontment(this.employeeId,6,3);
  }

  prevWeek(){
    this.getAllApppontment(this.employeeId,7,0);
 
  }
  schedualDetails(id:number){
    this._dialog.open(SchedualeDetailsComponent,{
       width:'70%',
       height:'80%',
      data: {
        Id: id,
        EmployeeId:this.employeeId
      },
      
    }).afterClosed().subscribe(val => {
        
    })
  
  }
  

}
