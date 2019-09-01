import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalSearchOutputComponent } from './global-search-output.component';

describe('GlobalSearchOutputComponent', () => {
  let component: GlobalSearchOutputComponent;
  let fixture: ComponentFixture<GlobalSearchOutputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GlobalSearchOutputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GlobalSearchOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
