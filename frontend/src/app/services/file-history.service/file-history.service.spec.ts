import { TestBed } from '@angular/core/testing';

import { FileHistoryService } from './file-history.service';

describe('FileHistoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileHistoryService = TestBed.get(FileHistoryService);
    expect(service).toBeTruthy();
  });
});
