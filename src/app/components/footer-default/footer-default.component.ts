import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer-default',
  templateUrl: './footer-default.component.html',
  styleUrls: ['./footer-default.component.scss']
})
export class FooterDefaultComponent {
  constructor(private router: Router) {}

  mostrarCabRod() {
    return !this.router.url.includes('login') && !this.router.url.includes('signup');
  }
}
