import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WFMService } from 'src/app/Services/wfm.service';

@Component({
  selector: 'app-add-appointment-form',
  templateUrl: './add-appointment-form.component.html',
  styleUrls: ['./add-appointment-form.component.css']
})
export class AddAppointmentFormComponent implements OnInit{

  addAppointmentForm!: FormGroup
  selected = [];
  addBreakBtn = false
  typesOfDay:any
  constructor(private _fb:FormBuilder, private _wfmService:WFMService) {
    
  }
  ngOnInit(): void {
    this.addAppointmentForm = this._fb.group({
      typeOfDayId :['',Validators.required],
      appointMentDate: ['', Validators.required],
      from: ['', Validators.required],
      to: ['', Validators.required],
      breaks: this._fb.array([
      ]),

    })

    this.AllTypesOfDay();
  }

  get breaks(){
    return this.addAppointmentForm.get('breaks') as FormArray;
  }

  addBreak(){
    this.breaks.push(this._fb.group({
      from: ['', Validators.required],
      to: ['', Validators.required],
    }))
  }

  removeBreak(i:any){
    this.breaks.removeAt(i);
  }

  onCheckChange(event:any){
    const from = '00:00'
    const to = '00:00'
    if (event.target.checked) {
      this.addAppointmentForm.get('from')?.setValue(from);
      this.addAppointmentForm.get('to')?.setValue(to);
      this.addBreakBtn = true

     // alert('I am Checked')
    }else{
      this.addAppointmentForm.get('from')?.setValue('');
      this.addAppointmentForm.get('to')?.setValue('');
      this.addBreakBtn = false

    }
  }


  AllTypesOfDay(){
    this._wfmService.GetAllTypesOfDay().subscribe({
      next:(res)=>{
        this.typesOfDay = res  
        console.log(this.typesOfDay)
      },
      error:(err)=>{
        alert("Types Of Day not found")
        console.log(err)
      }
    })
  }
}
