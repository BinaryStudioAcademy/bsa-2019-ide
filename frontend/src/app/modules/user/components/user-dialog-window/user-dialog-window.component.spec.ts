import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDialogWindowComponent } from './user-dialog-window.component';

describe('UserDialogWindowComponent', () => {
  let component: UserDialogWindowComponent;
  let fixture: ComponentFixture<UserDialogWindowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserDialogWindowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDialogWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
