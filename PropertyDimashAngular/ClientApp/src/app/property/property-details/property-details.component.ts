import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidentialComplexService } from '../../residentialComplex/residential-complex.service';
import { PropertyService } from '../../shared/property.service';
import { Property } from '../property';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
  id: string = "";
  userId: string = "";
  property!: Property;
  residentialComplexName: string = "";
  constructor(private service: PropertyService, private ResidentialComplexService: ResidentialComplexService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['propertyId'];
    this.userId = localStorage.getItem('UserId')!;
    this.service.getProperty(this.id).subscribe((data: Property) => {
      this.property = data;
    });
    this.ResidentialComplexService.getResidentialComplex(this.property.residentialComplexId).subscribe(res => {
      this.residentialComplexName = res.residentialComplexName;
    });
  }

  deleteProperty(id: string) {
    this.service.deleteProperty(id).subscribe(res => {
      this.router.navigateByUrl('/properties/index');
    })
  }
}
