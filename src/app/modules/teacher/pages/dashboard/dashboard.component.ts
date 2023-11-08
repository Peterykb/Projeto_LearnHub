import { Component, OnInit } from '@angular/core';
import { AuthTeacherService } from 'src/app/services/auth-teacher.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(
    private authTeacher: AuthTeacherService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if(this.authTeacher.isLoggedIn()){
      this.router.navigate(['./teacher'])
    }
  }

  logout() {
    this.authTeacher.logout();
  }
}
