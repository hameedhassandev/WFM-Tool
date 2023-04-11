import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WfmHeaderComponent } from './wfm-header.component';

describe('WfmHeaderComponent', () => {
  let component: WfmHeaderComponent;
  let fixture: ComponentFixture<WfmHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WfmHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WfmHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
