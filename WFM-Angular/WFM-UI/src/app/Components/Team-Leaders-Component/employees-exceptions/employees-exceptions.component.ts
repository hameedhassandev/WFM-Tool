import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-employees-exceptions',
  templateUrl: './employees-exceptions.component.html',
  styleUrls: ['./employees-exceptions.component.css']
})
export class EmployeesExceptionsComponent implements OnInit{

  filterForm !:FormGroup

  constructor(private _fb:FormBuilder) {    
  }
  ngOnInit(): void {
    this.filterForm = this._fb.group({
      filterDate : ['', Validators.required],
    })
    throw new Error('Method not implemented.');
  }

  filterByDate(){

  }

}
