import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthTeacherService } from 'src/app/services/auth-teacher.service';
import { AuthUserService } from 'src/app/services/auth-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: any;
  formSubmitted: boolean = false;
  showPass: boolean = false;
  constructor(
    private loginBuilder: FormBuilder,
    private router: Router,
    private authUser: AuthUserService,
    private authTeacher: AuthTeacherService
  ) {
    this.loginForm = loginBuilder.group({
      email: ['', [Validators.required /*  this.emailValidator */]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }
  ngOnInit(): void {
  }

  onSubmit() {
    this.formSubmitted = true;

    if (!this.loginForm.valid) {
      alert('form invalido')
    } else {

      const   loginData = this.loginForm.value

      if(this.isTeacherEmail(loginData.email)){
        this.authTeacher.loginTeacher(loginData).subscribe(
          (res) => {
            this.router.navigate(['instrutor', 'overview']);
          },
          (err: Error) => {
            alert(err.message);
          }
        );
      } else{
        this.authUser.login(loginData).subscribe(
          (res) => {
            this.router.navigate(['home']);
          },
          (err: Error) => {
            alert(err.message);
          }
        );
      }
    }
  }

  passShow(){
    this.showPass = !this.showPass;
  }

  get email() {
    return this.loginForm.get('email')!;
  }

  get password() {
    return this.loginForm.get('password')!;
  }

  isTeacherEmail(email: string): boolean{
    const teacherEmailRegex = /@professor\.com$/i;

    return teacherEmailRegex.test(email)
  }
}
