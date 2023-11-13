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

import { AuthTeacherService } from '../services/auth-teacher.service';
@Injectable({
  providedIn: 'root',
})
export class TeacherGuard implements CanActivate {
  constructor(
    private router: Router,
    private authTeacher: AuthTeacherService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (!this.authTeacher.isLoggedIn()) {
      this.router.navigate(['/home']);
    }
    return this.authTeacher.isLoggedIn();
  }
}
