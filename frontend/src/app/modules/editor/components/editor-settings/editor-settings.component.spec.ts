import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorSettingsComponent } from './editor-settings.component';

describe('EditorSettingsComponent', () => {
  let component: EditorSettingsComponent;
  let fixture: ComponentFixture<EditorSettingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorSettingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
