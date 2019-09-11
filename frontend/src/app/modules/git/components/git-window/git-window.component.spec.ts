import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GitWindowComponent } from './git-window.component';

describe('GitWindowComponent', () => {
  let component: GitWindowComponent;
  let fixture: ComponentFixture<GitWindowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GitWindowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GitWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
