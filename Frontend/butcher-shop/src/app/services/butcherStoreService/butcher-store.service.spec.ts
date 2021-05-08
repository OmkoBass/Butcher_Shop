import { TestBed } from '@angular/core/testing';

import { ButcherStoreService } from './butcher-store.service';

describe('ButcherStoreService', () => {
  let service: ButcherStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ButcherStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
