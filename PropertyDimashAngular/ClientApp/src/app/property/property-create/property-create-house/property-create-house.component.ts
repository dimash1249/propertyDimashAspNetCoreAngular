import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PropertyService } from '../../../shared/property.service';

@Component({
  selector: 'app-property-create-house',
  templateUrl: './property-create-house.component.html',
  styleUrls: ['./property-create-house.component.css']
})
export class PropertyCreateHouseComponent implements OnInit {
  propertyForm;
  constructor(private PropertyService: PropertyService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) {
    this.propertyForm = this.formBuilder.group({
      type: ['', Validators.required],
      propertyType: ['', Validators.required],
      roomNumber: ['', Validators.required],
      price: ['', Validators.required],
      typeOfBuilding: ['', Validators.required],
      yearOfBuilding: ['', Validators.required],
      totalArea: ['', Validators.required],
      addressStreet: ['', Validators.required],
      addressNumber: ['', Validators.required],
      condition: ['', Validators.required],
      telephone: ['', Validators.required],
      internet: ['', Validators.required],
      bathroom: ['', Validators.required],
      heightOfCeiling: ['', Validators.required],
      security: ['', Validators.required],
      different: ['', Validators.required],
      userId: ['', Validators.required],
      //images: ['', Validators.required],
      userTelephone: ['', Validators.required],
      userEmail: ['', Validators.required],
      sewageSystem: ['', Validators.required],
      drinkingWater: ['', Validators.required],
      electricity: ['', Validators.required],
      heating: ['', Validators.required],
      gas: ['', Validators.required],
      roofCovering: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(formData: any) {

  }
}
