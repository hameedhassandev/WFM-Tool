import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllExceptionsComponent } from './all-exceptions.component';

describe('AllExceptionsComponent', () => {
  let component: AllExceptionsComponent;
  let fixture: ComponentFixture<AllExceptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllExceptionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllExceptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
