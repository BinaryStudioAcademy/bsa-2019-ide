import { TestBed } from '@angular/core/testing';

import { GitDialogService } from './git-dialog.service';

describe('GitDialogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GitDialogService = TestBed.get(GitDialogService);
    expect(service).toBeTruthy();
  });
});
