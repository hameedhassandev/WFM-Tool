import { Component } from '@angular/core';

@Component({
  selector: 'app-manage-empl-appointment',
  templateUrl: './manage-empl-appointment.component.html',
  styleUrls: ['./manage-empl-appointment.component.css']
})
export class ManageEmplAppointmentComponent {

  typeOfDays = [{id:2,name:"Anuual"},
                {id:3,name:"Work"},
                {id:4,name:"Day Off"}]
}
