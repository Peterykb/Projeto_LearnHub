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

@Injectable({
  providedIn: 'root',
})
export class TeacherGuard implements CanActivate {
  constructor(
    private router: Router  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
   return false;
  }
}
