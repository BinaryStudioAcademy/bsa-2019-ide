import { TestBed } from '@angular/core/testing';

import { SearchFileService } from './search-file.service';

describe('SearchFileService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SearchFileService = TestBed.get(SearchFileService);
    expect(service).toBeTruthy();
  });
});
