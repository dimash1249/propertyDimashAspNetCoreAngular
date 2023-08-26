import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResidentialComplexDetailsComponent } from './residential-complex-details.component';

describe('ResidentialComplexDetailsComponent', () => {
  let component: ResidentialComplexDetailsComponent;
  let fixture: ComponentFixture<ResidentialComplexDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResidentialComplexDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResidentialComplexDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
