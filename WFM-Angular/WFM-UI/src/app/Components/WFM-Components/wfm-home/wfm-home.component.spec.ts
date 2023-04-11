import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WfmHomeComponent } from './wfm-home.component';

describe('WfmHomeComponent', () => {
  let component: WfmHomeComponent;
  let fixture: ComponentFixture<WfmHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WfmHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WfmHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
