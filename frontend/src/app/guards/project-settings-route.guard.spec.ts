import { TestBed, async, inject } from '@angular/core/testing';

import { ProjectSettingsRouteGuard } from './project-settings-route.guard';

describe('GetRouteAuthorGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProjectSettingsRouteGuard]
    });
  });

  it('should ...', inject([ProjectSettingsRouteGuard], (guard: ProjectSettingsRouteGuard) => {
    expect(guard).toBeTruthy();
  }));
});
