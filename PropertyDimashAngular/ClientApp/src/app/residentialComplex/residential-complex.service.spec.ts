import { TestBed } from '@angular/core/testing';

import { ResidentialComplexService } from './residential-complex.service';

describe('ResidentialComplexService', () => {
  let service: ResidentialComplexService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResidentialComplexService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
