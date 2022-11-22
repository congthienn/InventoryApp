import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddWarehouseShelveComponent } from './add-warehouse-shelve.component';

describe('AddWarehouseShelveComponent', () => {
  let component: AddWarehouseShelveComponent;
  let fixture: ComponentFixture<AddWarehouseShelveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddWarehouseShelveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddWarehouseShelveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
