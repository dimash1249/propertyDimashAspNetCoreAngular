import { Component, OnInit } from '@angular/core';
import { UserService } from '../../user/user.service';
import { ResidentialComplex } from '../residential-complex';
import { ResidentialComplexService } from '../residential-complex.service';

@Component({
  selector: 'app-residential-complex-index',
  templateUrl: './residential-complex-index.component.html',
  styleUrls: ['./residential-complex-index.component.css']
})
export class ResidentialComplexIndexComponent implements OnInit {
  residentialComplexes: ResidentialComplex[] = [];
  constructor(private ResidentialComplexService: ResidentialComplexService, public UserService: UserService) { }

  ngOnInit(): void {
    this.ResidentialComplexService.getResidentialComplexes().subscribe((data: ResidentialComplex[]) => {
      this.residentialComplexes = data;
      //for (var i of residentialComplexesFrom) {
      //  this.residentialComplexes.push(data[i]);
      //}
      //console.log(residentialComplexesFrom);
    });
  }

  deleteResidentialComplex(id: string) {
    this.ResidentialComplexService.deleteResidentialComplex(id).subscribe(res => {
      this.residentialComplexes = this.residentialComplexes.filter(item => item.id != id);
    });
  }

}
