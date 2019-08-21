import { TestBed } from '@angular/core/testing';

import { ProjectDialogService } from './project-dialog.service';

describe('ProjectDialogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProjectDialogService = TestBed.get(ProjectDialogService);
    expect(service).toBeTruthy();
  });
});
