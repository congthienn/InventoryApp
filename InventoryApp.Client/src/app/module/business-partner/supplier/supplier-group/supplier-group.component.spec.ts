import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierGroupComponent } from './supplier-group.component';

describe('SupplierGroupComponent', () => {
  let component: SupplierGroupComponent;
  let fixture: ComponentFixture<SupplierGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SupplierGroupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
