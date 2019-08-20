import { TestBed } from '@angular/core/testing';

import { CollaborateService } from './collaborate.service';

describe('CollaborateService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CollaborateService = TestBed.get(CollaborateService);
    expect(service).toBeTruthy();
  });
});
