import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidentialComplex } from '../../residentialComplex/residential-complex';
import { ResidentialComplexService } from '../../residentialComplex/residential-complex.service';
import { PropertyService } from '../../shared/property.service';

@Component({
  selector: 'app-property-create',
  templateUrl: './property-create.component.html',
  styleUrls: ['./property-create.component.css']
})
export class PropertyCreateComponent implements OnInit {
  type: string = "";
  propertyType: string = "";
  error: boolean = false;
  constructor(private PropertyService: PropertyService, private ResidentialComplexService: ResidentialComplexService, private router: Router, private formBuilder: FormBuilder) {
    }

  ngOnInit(): void {
  }

  create() {
    if (this.type == "" || this.propertyType == "") {
      this.error = true;
    } else {
      if (localStorage.getItem('IsLoggedIn') == 'true') this.router.navigateByUrl('/properties/' + this.type + '/' + this.propertyType + '/create');
      else this.router.navigateByUrl('/user/login');
    }
  }
}
