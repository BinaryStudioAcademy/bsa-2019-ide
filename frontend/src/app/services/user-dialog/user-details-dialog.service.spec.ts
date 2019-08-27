import { TestBed } from '@angular/core/testing';

import { UserDetailsDialogService } from './user-details-dialog.service';

describe('UserDetailsDialogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserDetailsDialogService = TestBed.get(UserDetailsDialogService);
    expect(service).toBeTruthy();
  });
});
