import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RunInputComponent } from './run-input.component';

describe('RunInputComponent', () => {
  let component: RunInputComponent;
  let fixture: ComponentFixture<RunInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RunInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RunInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
