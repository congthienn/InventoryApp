import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionButtonWarehouseShelveComponent } from './action-button-warehouse-shelve.component';

describe('ActionButtonWarehouseShelveComponent', () => {
  let component: ActionButtonWarehouseShelveComponent;
  let fixture: ComponentFixture<ActionButtonWarehouseShelveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionButtonWarehouseShelveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionButtonWarehouseShelveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
