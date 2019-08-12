import { TestBed } from '@angular/core/testing';

import { FileBrowserService } from './file-browser.service';

describe('FileBrowserService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileBrowserService = TestBed.get(FileBrowserService);
    expect(service).toBeTruthy();
  });
});
