import { TestBed } from '@angular/core/testing';

import { ButcherService } from './butcher-service.service';

describe('ButcherServiceService', () => {
  let service: ButcherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ButcherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
