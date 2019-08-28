import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildHistoryTabComponent } from './build-history-tab.component';

describe('BuildHistoryTabComponent', () => {
  let component: BuildHistoryTabComponent;
  let fixture: ComponentFixture<BuildHistoryTabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuildHistoryTabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuildHistoryTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
