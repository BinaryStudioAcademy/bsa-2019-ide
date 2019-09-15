import { TestBed } from '@angular/core/testing';

import { FileSaverService } from './file-saver.service';

describe('FileSaverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileSaverService = TestBed.get(FileSaverService);
    expect(service).toBeTruthy();
  });
});
