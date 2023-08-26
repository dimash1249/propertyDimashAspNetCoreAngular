import { Component } from '@angular/core';
import { UserService } from './user/user.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  loginStatus = new BehaviorSubject<boolean>(false);
  constructor(private UserService: UserService) {
    this.UserService.setLogin(this.loginStatus);
    localStorage.setItem('UserName', '-');
    localStorage.setItem('UserId', '-');
  }
}
