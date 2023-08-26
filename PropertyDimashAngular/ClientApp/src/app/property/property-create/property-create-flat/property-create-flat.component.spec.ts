import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyCreateFlatComponent } from './property-create-flat.component';

describe('PropertyCreateFlatComponent', () => {
  let component: PropertyCreateFlatComponent;
  let fixture: ComponentFixture<PropertyCreateFlatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyCreateFlatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PropertyCreateFlatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
