import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectDetailsInfoComponent } from './project-details-info.component';

describe('ProjectDetailsInfoComponent', () => {
  let component: ProjectDetailsInfoComponent;
  let fixture: ComponentFixture<ProjectDetailsInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectDetailsInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectDetailsInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
