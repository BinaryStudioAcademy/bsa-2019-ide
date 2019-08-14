import { TestBed, async, inject } from '@angular/core/testing';

import { SaveBeforeExitGuard } from './save-before-exit.guard';

describe('SaveBeforeExitGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SaveBeforeExitGuard]
    });
  });

  it('should ...', inject([SaveBeforeExitGuard], (guard: SaveBeforeExitGuard) => {
    expect(guard).toBeTruthy();
  }));
});
