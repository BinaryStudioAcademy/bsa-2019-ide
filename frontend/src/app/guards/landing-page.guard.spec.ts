import { TestBed, async, inject } from '@angular/core/testing';

import { LangingPageGuard } from './langing-page.guard';

describe('LangingPageGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LangingPageGuard]
    });
  });

  it('should ...', inject([LangingPageGuard], (guard: LangingPageGuard) => {
    expect(guard).toBeTruthy();
  }));
});
