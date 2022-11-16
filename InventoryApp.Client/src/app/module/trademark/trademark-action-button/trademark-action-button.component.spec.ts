import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrademarkActionButtonComponent } from './trademark-action-button.component';

describe('TrademarkActionButtonComponent', () => {
  let component: TrademarkActionButtonComponent;
  let fixture: ComponentFixture<TrademarkActionButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrademarkActionButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrademarkActionButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
