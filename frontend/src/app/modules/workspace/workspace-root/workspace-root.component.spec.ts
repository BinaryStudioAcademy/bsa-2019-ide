import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkspaceRootComponent } from './workspace-root.component';

describe('WorkspaceRootComponent', () => {
  let component: WorkspaceRootComponent;
  let fixture: ComponentFixture<WorkspaceRootComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkspaceRootComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkspaceRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
