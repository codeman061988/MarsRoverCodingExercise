import { TestBed, inject } from '@angular/core/testing';

import { MarsService } from './mars.service';

describe('MarsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MarsService]
    });
  });

  it('should be created', inject([MarsService], (service: MarsService) => {
    expect(service).toBeTruthy();
  }));
});
