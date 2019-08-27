import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryChangesComponent } from './history-changes.component';

describe('HistoryChangesComponent', () => {
  let component: HistoryChangesComponent;
  let fixture: ComponentFixture<HistoryChangesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoryChangesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryChangesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
