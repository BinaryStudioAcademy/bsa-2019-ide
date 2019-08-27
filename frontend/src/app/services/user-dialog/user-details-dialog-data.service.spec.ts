import { TestBed } from '@angular/core/testing';

import { UserDetailsDialogDataService } from './user-details-dialog-data.service';

describe('UserDetailsDialogDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserDetailsDialogDataService = TestBed.get(UserDetailsDialogDataService);
    expect(service).toBeTruthy();
  });
});
