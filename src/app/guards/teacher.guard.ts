import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class TeacherGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {

    const isLogged = this.authService.isLoggedIn();

    if (isLogged) {
      return true;
    } else {
      this.router.navigate(['/home']);
      return false;
    }
  }
}
