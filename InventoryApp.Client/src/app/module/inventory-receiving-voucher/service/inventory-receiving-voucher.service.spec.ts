import { TestBed } from '@angular/core/testing';

import { InventoryReceivingVoucherService } from './inventory-receiving-voucher.service';

describe('InventoryReceivingVoucherService', () => {
  let service: InventoryReceivingVoucherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InventoryReceivingVoucherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
