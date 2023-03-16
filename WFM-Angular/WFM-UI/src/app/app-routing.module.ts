import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { EmployeeScheduleComponent } from './Components/Employee-Components/employee-schedule/employee-schedule.component';
import { ManageEmplAppointmentComponent } from './Components/WFM-Components/manage-empl-appointment/manage-empl-appointment.component';
import { MyExceptionsComponent } from './Components/Employee-Components/my-exceptions/my-exceptions.component';
import { CreateExceptionComponent } from './Components/Employee-Components/create-exception/create-exception.component';
import { FindOrdisputeExceptionComponent } from './Components/Employee-Components/find-ordispute-exception/find-ordispute-exception.component';
import { EmployeesExceptionsComponent } from './Components/Team-Leaders-Component/employees-exceptions/employees-exceptions.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'employee-scheduale', component:EmployeeScheduleComponent},
  {path:'manage-appointment', component:ManageEmplAppointmentComponent},
  {path:'my-exception', component:MyExceptionsComponent},
  {path:'create-exception', component:CreateExceptionComponent},
  {path:'find-or-dispute-exception', component:FindOrdisputeExceptionComponent},

  {path:'employess-exceptions', component:EmployeesExceptionsComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
