import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { PopupErrorService } from 'src/app/service/popup-error.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  loginForm: any;
  formSubmitted: boolean = false
  constructor(private loginBuilder: FormBuilder, private router: Router, private popupService: PopupErrorService) {
    this.loginForm = loginBuilder.group({
      email: ['', [Validators.required,/*  this.emailValidator */]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    })
  }
  ngOnInit(): void {}

  onSubmit(){

    this.formSubmitted = true;

    if(!this.loginForm.valid){
      this.popupService.addMessage('Preencha os campos obrigatórios!')

    }
    else{
      if(this.email.value === "email@email.com" && this.password.value === "12345678"){
        this.router.navigate(['home'])
      }else{
        this.popupService.addMessage('Usuário e/ou Senha inválido(a)(s)!')
        this.router.navigate(['login'])
      }
    }
  }
/*
  emailValidator(control: AbstractControl): { [key: string]: any } | null {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (control.value && !emailPattern.test(control.value)) {
      return { 'invalidEmail': true };
    }

    return null;
  } */

  get email(){
    return this.loginForm.get('email')!
  }

  get password(){
    return this.loginForm.get('password')!
  }
}
