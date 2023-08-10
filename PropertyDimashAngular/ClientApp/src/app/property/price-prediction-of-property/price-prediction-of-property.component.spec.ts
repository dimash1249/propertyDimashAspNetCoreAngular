import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PricePredictionOfPropertyComponent } from './price-prediction-of-property.component';

describe('PricePredictionOfPropertyComponent', () => {
  let component: PricePredictionOfPropertyComponent;
  let fixture: ComponentFixture<PricePredictionOfPropertyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PricePredictionOfPropertyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PricePredictionOfPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
