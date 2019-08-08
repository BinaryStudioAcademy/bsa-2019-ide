import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileBrowserSectionComponent } from './file-browser-section.component';

describe('FileBrowserSectionComponent', () => {
  let component: FileBrowserSectionComponent;
  let fixture: ComponentFixture<FileBrowserSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileBrowserSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileBrowserSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
