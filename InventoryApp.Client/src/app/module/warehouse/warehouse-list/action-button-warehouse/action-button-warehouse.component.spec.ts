import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionButtonWarehouseComponent } from './action-button-warehouse.component';

describe('ActionButtonWarehouseComponent', () => {
  let component: ActionButtonWarehouseComponent;
  let fixture: ComponentFixture<ActionButtonWarehouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionButtonWarehouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionButtonWarehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
