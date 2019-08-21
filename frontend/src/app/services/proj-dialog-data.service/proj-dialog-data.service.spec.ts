import { TestBed } from '@angular/core/testing';

import { ProjDialogDataService } from './proj-dialog-data.service';

describe('ProjDialogDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProjDialogDataService = TestBed.get(ProjDialogDataService);
    expect(service).toBeTruthy();
  });
});
