import { TestBed } from '@angular/core/testing';

import { EditorSettingsService } from './editor-settings.service';

describe('EditorSettingsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EditorSettingsService = TestBed.get(EditorSettingsService);
    expect(service).toBeTruthy();
  });
});
