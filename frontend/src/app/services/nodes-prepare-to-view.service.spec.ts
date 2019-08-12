import { TestBed } from '@angular/core/testing';

import { NodesPrepareToViewService } from './nodes-prepare-to-view.service';

describe('NodesPrepareToViewService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NodesPrepareToViewService = TestBed.get(NodesPrepareToViewService);
    expect(service).toBeTruthy();
  });
});
