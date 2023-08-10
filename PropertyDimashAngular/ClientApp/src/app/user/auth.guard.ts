import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private UserService: UserService) {
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null) {
      let roles = route.data['permittedRoles'] as Array<string>;
      if (roles) {
        if (this.UserService.roleMatch(roles)) return true;
        else {
          this.router.navigateByUrl('/forbidden');
          return false;
        }
      }

      return true;
    } else {
      this.router.navigateByUrl('/user/login');
      return false;
    }
  }
  
}
