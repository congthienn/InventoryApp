import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmDeliveryCompanyComponent } from './confirm-delivery-company.component';

describe('ConfirmDeliveryCompanyComponent', () => {
  let component: ConfirmDeliveryCompanyComponent;
  let fixture: ComponentFixture<ConfirmDeliveryCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfirmDeliveryCompanyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmDeliveryCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
