import { TestBed } from '@angular/core/testing';

import { FileEditService } from './file-edit.service';

describe('FileEditService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileEditService = TestBed.get(FileEditService);
    expect(service).toBeTruthy();
  });
});
