import { TestBed } from '@angular/core/testing';

import { LeavePageDialogService } from './leave-page-dialog.service';

describe('LeavePageDialogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LeavePageDialogService = TestBed.get(LeavePageDialogService);
    expect(service).toBeTruthy();
  });
});
