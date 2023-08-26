import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userLoginForm;
  constructor(private UserService: UserService, private router: Router, private formBuilder: FormBuilder) {
    this.userLoginForm = this.formBuilder.group({
      UserName: ['', Validators.required],
      Password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(formData: any) {
    this.UserService.loginUser(formData.value).subscribe((res: any) => {
      this.UserService.login();
      localStorage.setItem("token", res.token);
      localStorage.setItem('UserName', res.userName);
      localStorage.setItem('UserId', res.id);
      localStorage.setItem('IsLoggedIn', "true");
      this.UserService.login();
      this.router.navigateByUrl('');
    },
    err => {
      console.log(err);
    });
  }
}
