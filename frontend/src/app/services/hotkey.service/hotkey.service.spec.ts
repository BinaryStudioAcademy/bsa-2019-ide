import { TestBed } from '@angular/core/testing';

import { HotkeyService } from './hotkey.service';

describe('HotkeyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HotkeyService = TestBed.get(HotkeyService);
    expect(service).toBeTruthy();
  });
});
