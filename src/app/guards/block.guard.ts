import { Injectable } from '@angular/core';

import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanDeactivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { AuthTeacherService } from '../services/auth-teacher.service';
import { AuthUserService } from '../services/auth-user.service';
@Injectable({
  providedIn: 'root',
})
export class BlockGuard implements CanActivate {
  constructor(
    private router: Router,
    private authTeacher: AuthTeacherService,
    private authUser: AuthUserService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (this.authTeacher.isLoggedIn()) {
      this.router.navigate(['teacher']);
    }
    return !this.authTeacher.isLoggedIn();
  }
}
