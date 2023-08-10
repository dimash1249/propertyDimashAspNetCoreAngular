import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ResidentialComplex } from '../../residentialComplex/residential-complex';
import { PropertyService } from '../../shared/property.service';
import { ResidentialComplexService } from '../../residentialComplex/residential-complex.service';

@Component({
  selector: 'app-price-prediction-of-property',
  templateUrl: './price-prediction-of-property.component.html',
  styleUrls: ['./price-prediction-of-property.component.css']
})
export class PricePredictionOfPropertyComponent implements OnInit {
  propertyForm;
  priceOfProperty: number = 0;
  residentialComplexes: ResidentialComplex[] = [];
  constructor(private PropertyService: PropertyService, private ResidentialComplexService: ResidentialComplexService, private formBuilder: FormBuilder) {
    this.propertyForm = this.formBuilder.group({
      year: ['', Validators.required],
      type: ['', Validators.required],
      real_floor: [0, Validators.required],
      from_floor: [0, Validators.required],
      area: [0, Validators.required],
      ceiling: [0, Validators.required],
      Condition: ['', Validators.required],
      Bathroom: ['', Validators.required],
      Door: ['', Validators.required],
      Parking: ['', Validators.required],
      Floor: ['', Validators.required],
      Security: ['', Validators.required],
      FormarDormitory: ['', Validators.required],
      Balcony: ['', Validators.required],
      BalconyGlazed: ['', Validators.required],
      Telephone: ['', Validators.required],
      ResidentialComplex: ['', Validators.required],
      PropertyFurnished: ['', Validators.required],
      Internet: ['', Validators.required],
    }); }

  ngOnInit(): void {
    this.ResidentialComplexService.getResidentialComplexes().subscribe((res: ResidentialComplex[]) => {
      this.residentialComplexes = res;
    })
  }

  onSubmit(formData: any) {
    this.PropertyService.pricePredictionOfProperty(formData.value).subscribe((res: number) => {
      this.priceOfProperty = res;
      console.log(res);
    })
  }
}
