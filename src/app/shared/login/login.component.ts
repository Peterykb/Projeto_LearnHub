import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthUserService } from 'src/app/service/auth-user.service';
import { PopupErrorService } from 'src/app/service/popup-error.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: any;
  formSubmitted: boolean = false;
  constructor(
    private loginBuilder: FormBuilder,
    private router: Router,
    private popupService: PopupErrorService,
    private authUser: AuthUserService
  ) {
    this.loginForm = loginBuilder.group({
      email: ['', [Validators.required /*  this.emailValidator */]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }
  ngOnInit(): void {
    if(this.authUser.isLoggedIn()){
      this.router.navigate(['teacher'])
    }
  }

  onSubmit() {
    this.formSubmitted = true;

    if (!this.loginForm.valid) {
      this.popupService.addMessage('Preencha os campos obrigatórios!');
    } else {
      this.authUser.login(this.loginForm.value).subscribe(res => {
        this.router.navigate(['home'])
      }, (err: Error) =>{
        alert(err.message)
      })
    }
  }

  get email() {
    return this.loginForm.get('email')!;
  }

  get password() {
    return this.loginForm.get('password')!;
  }
}
