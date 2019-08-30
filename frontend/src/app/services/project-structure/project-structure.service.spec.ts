import { TestBed } from '@angular/core/testing';

import { ProjectStructureService } from './project-structure.service';

describe('ProjectStructureService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProjectStructureService = TestBed.get(ProjectStructureService);
    expect(service).toBeTruthy();
  });
});
