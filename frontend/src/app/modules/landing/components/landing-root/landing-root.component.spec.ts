import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingRootComponent } from './landing-root.component';

describe('LandingRootComponent', () => {
  let component: LandingRootComponent;
  let fixture: ComponentFixture<LandingRootComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LandingRootComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
