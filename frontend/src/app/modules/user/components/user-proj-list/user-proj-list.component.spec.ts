import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProjListComponent } from './user-proj-list.component';

describe('UserProjListComponent', () => {
  let component: UserProjListComponent;
  let fixture: ComponentFixture<UserProjListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserProjListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserProjListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
