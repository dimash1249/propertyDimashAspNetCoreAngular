import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidentialComplexService } from '../residential-complex.service';
import { v4 as uuidv4 } from 'uuid';
@Component({
  selector: 'app-residential-complex-create',
  templateUrl: './residential-complex-create.component.html',
  styleUrls: ['./residential-complex-create.component.css']
})
export class ResidentialComplexCreateComponent implements OnInit {
  residentialComplexForm;
  id: string = "";
  constructor(private ResidentialComplexService: ResidentialComplexService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) {
    this.id = uuidv4();
    this.residentialComplexForm = this.formBuilder.group({
      residentialComplexName: ['', Validators.required],
      addressStreet: ['', Validators.required],
      addressNumber: ['', Validators.required],
      id: [this.id]
    });
  }

  ngOnInit(): void {
    
  }

  onSubmit(formData: any) {
    this.ResidentialComplexService.createResidentialComplex(formData.value).subscribe(res => {
      this.router.navigateByUrl('/residential-complexes/index');
    })
  }
}
