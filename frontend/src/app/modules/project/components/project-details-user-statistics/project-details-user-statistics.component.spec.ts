import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectDetailsUserStatisticsComponent } from './project-details-user-statistics.component';

describe('ProjectDetailsUserStatisticsComponent', () => {
  let component: ProjectDetailsUserStatisticsComponent;
  let fixture: ComponentFixture<ProjectDetailsUserStatisticsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectDetailsUserStatisticsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectDetailsUserStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
