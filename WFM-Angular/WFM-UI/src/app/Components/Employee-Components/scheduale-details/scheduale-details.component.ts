import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-scheduale-details',
  templateUrl: './scheduale-details.component.html',
  styleUrls: ['./scheduale-details.component.css']
})
export class SchedualeDetailsComponent implements OnInit {

  constructor( private _dialog: MatDialogRef<SchedualeDetailsComponent>, @Inject(MAT_DIALOG_DATA) public details:any) {    
  }

  ngOnInit(): void {

}

}
