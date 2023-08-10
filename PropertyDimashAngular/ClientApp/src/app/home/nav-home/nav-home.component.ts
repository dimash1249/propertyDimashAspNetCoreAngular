import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { UserService } from '../../user/user.service';

@Component({
  selector: 'app-nav-home',
  templateUrl: './nav-home.component.html',
  styleUrls: ['./nav-home.component.css']
})
export class NavHomeComponent implements OnInit {
  isLoggedIn = new BehaviorSubject<boolean>(false);
  userName = new BehaviorSubject<string>('');
  constructor(private router: Router, public UserService: UserService) {this.isLoggedIn = this.UserService.getLoginStatus;
    this.userName = this.UserService.getUserName;
    console.log(this.isLoggedIn); }

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event.constructor.name === "NavigationEnd") {
        this.isLoggedIn = this.UserService.getLoginStatus;
      }
    })
  }

  loginStatus(): boolean {
    if (localStorage.getItem('IsLoggedIn')) {
      return true;
    }
    return false;
  }

  logout() {
    this.UserService.logout();//localStorage.removeItem('token');
    //localStorage.removeItem('UserName');
    //localStorage.setItem('IsLoggedIn', "false");
    this.router.navigateByUrl('');
  }

  getLoginStatus() {
    return this.isLoggedIn;
  }

  getUserName(): any {
    return this.userName;
  }

  UserName(): string {
    let userNameString = localStorage.getItem('UserName')!;
    if (localStorage.getItem('UserName') !== null) {
      return userNameString;
    } else {
      return "";
    }
  }
}
