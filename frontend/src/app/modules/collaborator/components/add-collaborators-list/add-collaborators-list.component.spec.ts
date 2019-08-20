import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCollaboratorsListComponent } from './add-collaborators-list.component';

describe('AddCollaboratorsListComponent', () => {
  let component: AddCollaboratorsListComponent;
  let fixture: ComponentFixture<AddCollaboratorsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCollaboratorsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCollaboratorsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
