import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { EmployeeScheduleComponent } from './Components/Employee-Components/employee-schedule/employee-schedule.component';
import { ManageEmplAppointmentComponent } from './Components/WFM-Components/manage-empl-appointment/manage-empl-appointment.component';
import { MyExceptionsComponent } from './Components/Employee-Components/my-exceptions/my-exceptions.component';
import { CreateExceptionComponent } from './Components/Employee-Components/create-exception/create-exception.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'employee-scheduale', component:EmployeeScheduleComponent},
  {path:'manage-appointment', component:ManageEmplAppointmentComponent},
  {path:'my-exception', component:MyExceptionsComponent},
  {path:'create-exception', component:CreateExceptionComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
