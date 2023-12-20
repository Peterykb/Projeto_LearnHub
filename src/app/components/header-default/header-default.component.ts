import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header-default',
  templateUrl: './header-default.component.html',
  styleUrls: ['./header-default.component.scss']
})
export class HeaderDefaultComponent {
  constructor(private router: Router, public authService: AuthService) {}

  mostrarCabRod() {
    return !this.router.url.includes('instrutor') && !this.router.url.includes('login') && !this.router.url.includes('register');
  }

  number = 2

}
