import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResidentialComplexCreateComponent } from './residential-complex-create.component';

describe('ResidentialComplexCreateComponent', () => {
  let component: ResidentialComplexCreateComponent;
  let fixture: ComponentFixture<ResidentialComplexCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResidentialComplexCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResidentialComplexCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
