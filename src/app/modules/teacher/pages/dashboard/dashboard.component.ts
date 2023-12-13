import { Component, OnInit } from '@angular/core';
import { AuthTeacherService } from 'src/app/services/auth-teacher.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  sidebarOpen: boolean = false;
  instrutorId!: string;
  constructor(
    private authTeacher: AuthTeacherService,
    private router: Router,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    if (this.authTeacher.isLoggedIn()) {
      const instrutorId = 0;  
      this.router.navigate([`./instrutor/${instrutorId}`]);
    }

  }

  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }

  logout() {
    const confirmLogout = confirm('Deseja mesmo sair?');
    if (confirmLogout === true) {
      this.auth.logout();
    } else {
      return;
    }
  }
}
