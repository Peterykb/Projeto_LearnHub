import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header-default',
  templateUrl: './header-default.component.html',
  styleUrls: ['./header-default.component.scss']
})
export class HeaderDefaultComponent {
  constructor(private router: Router) {}

  mostrarCabRod() {
    return !this.router.url.includes('instrutor') && !this.router.url.includes('login') && !this.router.url.includes('register');
  }

  number = 2

}
