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
  constructor(private _appointmentServ : EmployeeAppointmentService,public _dialog: MatDialog) {
    
  }
  ngOnInit(): void {
    this.getAllApppontment('6403e590-a212-4b2a-9ada-b8f03b90b25f');
  }

  getValue(event:any){
    console.log(event.target.value);
  }


  getAllApppontment(employeeId:string){
    this._appointmentServ.getAllEmployeeApointments(employeeId).subscribe({
      next:(res)=>{
        this.allAppointment = res  
        console.log(this.allAppointment)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  schedualDetails(){
    // this._dialog.open(SchedualeDetailsComponent,{
    //   width:'60%',
    //   height:'50%',
      
    // }).afterClosed().subscribe(val => {
        
    // })
    alert('Exception Details')
  }
  

}
