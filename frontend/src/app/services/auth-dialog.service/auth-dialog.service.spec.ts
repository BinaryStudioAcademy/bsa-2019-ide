import { TestBed } from '@angular/core/testing';

import { AuthDialogService } from './auth-dialog.service';

describe('AuthDialogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AuthDialogService = TestBed.get(AuthDialogService);
    expect(service).toBeTruthy();
  });
});
