import { TestBed } from '@angular/core/testing';

import { GitDialogDataService } from './git-dialog-data.service';

describe('GitDialogDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GitDialogDataService = TestBed.get(GitDialogDataService);
    expect(service).toBeTruthy();
  });
});
