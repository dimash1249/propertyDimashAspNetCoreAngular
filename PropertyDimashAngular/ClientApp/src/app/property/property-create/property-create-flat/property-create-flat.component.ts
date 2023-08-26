import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidentialComplex } from '../../../residentialComplex/residential-complex';
import { ResidentialComplexService } from '../../../residentialComplex/residential-complex.service';
import { UserService } from '../../../user/user.service';
import { PropertyService } from '../../../shared/property.service';
import { PropertyImage } from '../../property-image';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-property-create-flat',
  templateUrl: './property-create-flat.component.html',
  styleUrls: ['./property-create-flat.component.css']
})
export class PropertyCreateFlatComponent implements OnInit {
  propertyForm;
  residentialComplexesList: ResidentialComplex[] = [];
  type: string = "";
  propertyType: string = "";
  response: PropertyImage[] = [];
  id: string = "";
  addressStreet: string = "";
  addressNumber: string = "";
  userId: string = "";
  userEmail: string = "";
  constructor(private PropertyService: PropertyService, private ResidentialComplexService: ResidentialComplexService, private UserService: UserService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) {
    this.id = uuidv4();
    this.type = this.route.snapshot.params['type'];
    this.propertyType = this.route.snapshot.params['propertyType'];
    //this.UserService.getUser(localStorage.getItem('UserId')!).subscribe(res => {
      this.userId = localStorage.getItem('UserId')!;
      this.userEmail = localStorage.getItem('UserName')!;
    //  //this.propertyForm.patchValue({ 'userEmail': res.email });
    //});
    this.propertyForm = this.formBuilder.group({
      id: [this.id],
      type: [this.type, Validators.required],
      propertyType: [this.propertyType, Validators.required],
      roomNumber: [0, Validators.required],
      price: [0, Validators.required],
      typeOfBuilding: ['', Validators.required],
      yearOfBuilding: [2023, Validators.required],
      propertyFloor: [0, Validators.required],
      totalFloor: [0, Validators.required],
      totalArea: [0, Validators.required],
      addressStreet: ['', Validators.required],
      addressNumber: ['', Validators.required],
      condition: ['', Validators.required],
      telephone: ['', Validators.required],
      internet: ['', Validators.required],
      bathroom: ['', Validators.required],
      heightOfCeiling: [0, Validators.required],
      security: ['', Validators.required],
      different: ['', Validators.required],
      userId: [this.userId, Validators.required],
      images: ['', Validators.required],
      userTelephone: ['', Validators.required],
      userEmail: [this.userEmail, Validators.required],
      balcony: ['', Validators.required],
      balconyGlazed: [false, Validators.required],
      door: ['', Validators.required],
      parking: ['', Validators.required],
      propertyFurnished: ['', Validators.required],
      floor: ['', Validators.required],
      formerDormitory: [false, Validators.required],
      residentialComplexId: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    
    this.ResidentialComplexService.getResidentialComplexes().subscribe((data: ResidentialComplex[]) => {
      this.residentialComplexesList = data;
    });
  }

  onSubmit(formData: any) {
    formData.patchValue({ 'images': this.response });
    this.PropertyService.createPropertyFlat(formData.value).subscribe(res => {
      this.router.navigateByUrl('/properties/index');
    });
  }

  uploadFinished = (event: any) => {
    let id = uuidv4();
    this.response.push({ "id": id, "image": event.message, "propertyId": this.id });
    console.log(this.response);
  }

  onChangeResidentialComplex(value: any) {
    let residentialComplex = this.residentialComplexesList.filter(item => item.id == value.value);
    this.addressStreet = residentialComplex[0].addressStreet;
    this.addressNumber = residentialComplex[0].addressNumber;
    this.propertyForm.patchValue({ 'addressStreet': this.addressStreet });
    this.propertyForm.patchValue({ 'addressNumber': this.addressNumber });
  }
}
