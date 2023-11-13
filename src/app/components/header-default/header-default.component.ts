import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthUserService } from 'src/app/services/auth-user.service';

@Component({
  selector: 'app-header-default',
  templateUrl: './header-default.component.html',
  styleUrls: ['./header-default.component.scss']
})
export class HeaderDefaultComponent {
  constructor(private router: Router, public authUser: AuthUserService) {}

  mostrarCabRod() {
    return !this.router.url.includes('teacher') && !this.router.url.includes('login') && !this.router.url.includes('register');
  }

  number = 2

}
