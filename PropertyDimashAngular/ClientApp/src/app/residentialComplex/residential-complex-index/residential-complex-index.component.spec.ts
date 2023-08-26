import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResidentialComplexIndexComponent } from './residential-complex-index.component';

describe('ResidentialComplexIndexComponent', () => {
  let component: ResidentialComplexIndexComponent;
  let fixture: ComponentFixture<ResidentialComplexIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResidentialComplexIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResidentialComplexIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
