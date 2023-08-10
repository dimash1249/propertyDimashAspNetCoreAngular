import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, throwError } from 'rxjs';
import { User, UserLogin, UserRegistration } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  BaseUrl: string = "https://localhost:7074/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  authOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
      })
    }
  private loginStatus = new BehaviorSubject<boolean>(this.checkLoginStatus());
  private userName = new BehaviorSubject<string>(localStorage.getItem('UserName')!.toString());
  private userId = new BehaviorSubject<string>(localStorage.getItem('UserId')!.toString());
  constructor(private http: HttpClient) { }

  createUser(formData: any): Observable<UserRegistration> {
    return this.http.post<UserRegistration>(this.BaseUrl + '/User/Register', JSON.stringify(formData), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  loginUser(formData: any): Observable<UserLogin> {
    return this.http.post<UserLogin>(this.BaseUrl + '/User/Login', JSON.stringify(formData), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(this.BaseUrl + '/UserProfile/' + id, this.authOptions).pipe(catchError(this.errorHandler));
  }

  roleMatch(allowedRoles: any): boolean {
    var isMatch = false;
    const token = localStorage.getItem('token');
    var payLoad;
    if (token !== null) {
      payLoad = JSON.parse(window.atob(token.split('.')[1]));
    }
    var userRole = payLoad.role;
    console.log(userRole);
    allowedRoles.forEach((element: any) => {
      if (userRole == element) {
        isMatch = true;
      }
    });
    return isMatch;
  }

  setLogin(loginStatus: BehaviorSubject<boolean>) {
    this.loginStatus = loginStatus;
  }

  get getLoginStatus(): BehaviorSubject<boolean> {
    return this.loginStatus;
  }

  get getUserName(): BehaviorSubject<string> {
    return this.userName;
  }

  get getUserId(): BehaviorSubject<string> {
    return this.userId;
  }

  login() {
    this.loginStatus.next(true);
    this.userName.next(localStorage.getItem('UserName')!);
    this.userId.next(localStorage.getItem('UserId')!);
    localStorage.setItem('IsLoggedIn', 'true');
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.setItem('UserName', 'guest');
    localStorage.setItem('UserId', 'guestId');
    localStorage.setItem('IsLoggedIn', 'false');
    this.loginStatus.next(false);
    console.log(this.loginStatus);
  }

  checkLoginStatus(): boolean {
    return false;// localStorage.getItem('IsLoggedIn');
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = error.message;
    }
    return throwError(errorMessage);
  }
}
