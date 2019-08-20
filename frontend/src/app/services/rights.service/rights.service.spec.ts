import { TestBed } from '@angular/core/testing';

import { RightsService } from './rights.service';

describe('RightsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RightsService = TestBed.get(RightsService);
    expect(service).toBeTruthy();
  });
});
