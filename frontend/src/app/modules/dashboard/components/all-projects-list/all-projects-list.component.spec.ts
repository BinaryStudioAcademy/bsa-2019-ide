import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllProjectsListComponent } from './all-projects-list.component';

describe('AllProjectsListComponent', () => {
  let component: AllProjectsListComponent;
  let fixture: ComponentFixture<AllProjectsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllProjectsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllProjectsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
