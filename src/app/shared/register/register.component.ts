import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { faLock } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  faLock = faLock;
  formRegister: any;
  errorMessage: string = '';

  submitted: boolean = false;

  isActivated: boolean = false;

  constructor(private registerBuilder: FormBuilder) {
    this.formRegister = registerBuilder.group({
      nome_completo: ['', Validators.required],
      data_nascimento: ['', Validators.required],
      email: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$/i),
        ]),
      ],
      senha: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/
          ),
        ]),
      ],
      confirmar_senha: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/
          ),
        ]),
      ],
    });
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

  get email() {
    return this.formRegister.get('email')!;
  }

  get senha() {
    return this.formRegister.get('senha')!;
  }

  get confirmSenha() {
    return this.formRegister.get('confirmar_senha')!;
  }
}
