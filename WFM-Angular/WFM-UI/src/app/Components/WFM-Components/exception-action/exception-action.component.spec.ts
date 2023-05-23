import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExceptionActionComponent } from './exception-action.component';

describe('ExceptionActionComponent', () => {
  let component: ExceptionActionComponent;
  let fixture: ComponentFixture<ExceptionActionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExceptionActionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExceptionActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
