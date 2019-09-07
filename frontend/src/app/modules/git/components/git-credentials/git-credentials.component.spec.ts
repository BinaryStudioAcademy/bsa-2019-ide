import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GitCredentialsComponent } from './git-credentials.component';

describe('GitCredentialsComponent', () => {
  let component: GitCredentialsComponent;
  let fixture: ComponentFixture<GitCredentialsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GitCredentialsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GitCredentialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
