import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyCreateHouseComponent } from './property-create-house.component';

describe('PropertyCreateHouseComponent', () => {
  let component: PropertyCreateHouseComponent;
  let fixture: ComponentFixture<PropertyCreateHouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyCreateHouseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PropertyCreateHouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
