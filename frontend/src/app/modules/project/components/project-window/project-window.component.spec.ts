import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectWindowComponent } from './project-window.component';

describe('CreateProjectWindowComponent', () => {
  let component: ProjectWindowComponent;
  let fixture: ComponentFixture<ProjectWindowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectWindowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
