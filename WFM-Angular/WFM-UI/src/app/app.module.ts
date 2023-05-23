import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatMenuModule} from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeScheduleComponent } from './Components/Employee-Components/employee-schedule/employee-schedule.component';
import { ManageEmplAppointmentComponent } from './Components/WFM-Components/manage-empl-appointment/manage-empl-appointment.component';
import {MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule} from '@angular/material/dialog';
import { SchedualeDetailsComponent } from './Components/Employee-Components/scheduale-details/scheduale-details.component';
import { MyExceptionsComponent } from './Components/Employee-Components/my-exceptions/my-exceptions.component';
import { CreateExceptionComponent } from './Components/Employee-Components/create-exception/create-exception.component';
import { FindOrdisputeExceptionComponent } from './Components/Employee-Components/find-ordispute-exception/find-ordispute-exception.component';
import { EmployeesExceptionsComponent } from './Components/Team-Leaders-Component/employees-exceptions/employees-exceptions.component';
import { NavBarComponent } from './Components/Shared-Components/nav-bar/nav-bar.component';
import { HomeComponent } from './Components/Employee-Components/home/home.component';
import { PageNotFoundComponent } from './Components/Shared-Components/page-not-found/page-not-found.component';
import { CreateEmployeeComponent } from './Components/WFM-Components/create-employee/create-employee.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { WfmHeaderComponent } from './Components/WFM-Components/wfm-header/wfm-header.component';
import { WfmHomeComponent } from './Components/WFM-Components/wfm-home/wfm-home.component';
import { AllExceptionsComponent } from './Components/WFM-Components/all-exceptions/all-exceptions.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AddAppointmentFormComponent } from './Components/WFM-Components/add-appointment-form/add-appointment-form.component';
import { ExceptionActionComponent } from './Components/WFM-Components/exception-action/exception-action.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    EmployeeScheduleComponent,
    ManageEmplAppointmentComponent,
    SchedualeDetailsComponent,
    MyExceptionsComponent,
    CreateExceptionComponent,
    FindOrdisputeExceptionComponent,
    EmployeesExceptionsComponent,
    NavBarComponent,
    HomeComponent,
    PageNotFoundComponent,
    CreateEmployeeComponent,
    WfmHeaderComponent,
    WfmHomeComponent,
    AllExceptionsComponent,
    AddAppointmentFormComponent,
    ExceptionActionComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule ,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatMenuModule,
    BrowserAnimationsModule,
    Ng2SearchPipeModule,
    MatButtonModule,
    MatFormFieldModule,
    MatFormFieldModule,

  ],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
