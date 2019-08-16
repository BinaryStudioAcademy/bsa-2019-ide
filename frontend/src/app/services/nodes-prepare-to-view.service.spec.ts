import { TestBed } from '@angular/core/testing';

import { ProjectStructureFormaterService } from './nodes-prepare-to-view.service';

describe('ProjectStructureFormaterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProjectStructureFormaterService = TestBed.get(ProjectStructureFormaterService);
    expect(service).toBeTruthy();
  });
});
