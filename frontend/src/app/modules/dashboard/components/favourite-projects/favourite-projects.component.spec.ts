import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavouriteProjectsComponent } from './favourite-projects.component';

describe('FavouriteProjectsComponent', () => {
  let component: FavouriteProjectsComponent;
  let fixture: ComponentFixture<FavouriteProjectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouriteProjectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouriteProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
