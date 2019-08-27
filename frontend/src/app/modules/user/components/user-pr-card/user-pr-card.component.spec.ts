import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPrCardComponent } from './user-pr-card.component';

describe('UserPrCardComponent', () => {
  let component: UserPrCardComponent;
  let fixture: ComponentFixture<UserPrCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserPrCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPrCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
