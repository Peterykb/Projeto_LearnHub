import { Component } from '@angular/core';
import { AuthUserService } from './../../../../service/auth-user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  constructor(private authUser: AuthUserService) {}
  logout() {
    this.authUser.logout();
  }
}
