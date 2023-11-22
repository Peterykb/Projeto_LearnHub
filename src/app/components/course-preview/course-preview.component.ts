import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthUserService } from 'src/app/services/auth-user.service';

@Component({
  selector: 'app-course-preview',
  templateUrl: './course-preview.component.html',
  styleUrls: ['./course-preview.component.scss']
})
export class CoursePreviewComponent {

  constructor(private router: Router, private userService: AuthUserService){}

  verifyBuy(){
    if(!this.userService.isLoggedIn()){
      this.router.navigate(['login'])
    } else{
      this.router.navigate(['buy'])
    }
  }
}
