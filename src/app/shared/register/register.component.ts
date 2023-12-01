import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit{
  faLock = faLock;
  formRegister: any;
  errorMessage: string = '';
  regTeacher: boolean = false;
  isShowPass = false;
  isShowConfirmPass = false;
  isShowPassTeacher = false;
  isShowConfirmPassTeacher = false;

  submitted: boolean = false;

  isActivated: boolean = false;

  constructor(private router: Router, private registerService: RegisterService) {
  }

  ngOnInit() {
    this.formRegister = this.registerService.createRegisterForm();
  }

  onRegist() {
    this.submitted = true;
    if (this.formRegister.invalid) {
      return;
    } else {
      if (this.senha.value !== this.confirmSenha.value) {
        this.errorMessage = 'As senhas não coincidem';
      }
    }
    this.router.navigate(['login'])
  }

  onRegistTeacher(){
    this.submitted = true
    if(this.formRegister.invalid){
      return;
    }
    else{
      if(this.senha.value !== this.confirmSenha.value){
        this.errorMessage = "As senhas não coincidem"
      }
      this.router.navigate(['login'])
    }
  }

  showPass(){
    this.isShowPass = !this.isShowPass;
  }

  showConfirmPass(){
    this.isShowConfirmPass = !this.isShowConfirmPass;
  }

  showPassTeacher(){
    this.isShowPassTeacher = !this.isShowPassTeacher;
  }

  showConfirmPassTeacher(){
    this.isShowConfirmPassTeacher = !this.isShowConfirmPassTeacher;
  }

  registTeacher() {
    this.regTeacher = !this.regTeacher;
  }

  borda() {
    this.isActivated = true;
  }

  noBorda() {
    this.isActivated = false;
  }

  get nome() {
    return this.formRegister.get('nome_completo')!;
  }

  get dataNasc() {
    return this.formRegister.get('data_nascimento')!;
  }

  get cpf() {
    return this.formRegister.get('cpf')!;
  }

  get email() {
    return this.formRegister.get('email')!;
  }

  get senha() {
    return this.formRegister.get('senha')!;
  }

  get confirmSenha() {
    return this.formRegister.get('confirmar_senha')!;
  }

  updateCPFValue(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const cpfControl = this.formRegister.get('cpf');
    
    if (cpfControl) {
      cpfControl.setValue(this.registerService.formatCPF(inputElement.value));
    }
  }
}
