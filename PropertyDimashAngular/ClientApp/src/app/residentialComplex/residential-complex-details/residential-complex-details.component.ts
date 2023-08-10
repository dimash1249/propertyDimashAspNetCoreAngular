import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidentialComplex } from '../residential-complex';
import { ResidentialComplexService } from '../residential-complex.service';

@Component({
  selector: 'app-residential-complex-details',
  templateUrl: './residential-complex-details.component.html',
  styleUrls: ['./residential-complex-details.component.css']
})
export class ResidentialComplexDetailsComponent implements OnInit {
  id: string = "";
  residentialComplex!: ResidentialComplex;
  constructor(private ResidentialComplexService: ResidentialComplexService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['residentialComplexId'];
    this.ResidentialComplexService.getResidentialComplex(this.id).subscribe((data: ResidentialComplex) => {
      this.residentialComplex = data;
    });
  }

}
