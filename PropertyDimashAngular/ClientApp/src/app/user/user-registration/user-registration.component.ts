import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {
  userRegistrationForm;
  constructor(private UserService: UserService, private router: Router, private formBuilder: FormBuilder) {
    this.userRegistrationForm = this.formBuilder.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.email],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      //Passwords: this.formBuilder.group({
        Password: ['', Validators.required],
        ConfirmPassword: ['', Validators.required],
      //}),
    });
  }

  ngOnInit(): void {
  }

  comparePasswords(formBuilder: FormGroup) {
    let confirmPasswordControl = formBuilder.get('ConfirmPassword');

    if (confirmPasswordControl?.errors == null || 'passwordMismatch' in confirmPasswordControl.errors) {
      if (formBuilder.get('Password')?.value != confirmPasswordControl?.value) {
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl?.setErrors(null);
      }
    }
  }

  onSubmit(formData: any) {
    this.UserService.createUser(formData.value).subscribe(res => {
      this.router.navigateByUrl('');
    });
  }
}
