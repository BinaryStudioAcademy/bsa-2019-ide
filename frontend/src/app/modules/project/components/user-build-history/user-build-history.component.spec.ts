import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserBuildHistoryComponent } from './user-build-history.component';

describe('UserBuildHistoryComponent', () => {
  let component: UserBuildHistoryComponent;
  let fixture: ComponentFixture<UserBuildHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserBuildHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserBuildHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
