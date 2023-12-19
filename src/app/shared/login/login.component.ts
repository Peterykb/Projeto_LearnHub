import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

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
    private authService: AuthService,
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
      const credentials = {
        email: this.loginForm.get('email')!.value,
        password: this.loginForm.get('password')!.value
      }; // Obtém as credenciais do formulário

      this.authService.login(credentials).subscribe(
        (response) => {
          // Tratar a resposta do login bem-sucedido aqui
          console.log('Login bem-sucedido', response);
          this.authService.setToken(response.token); // Salva o token no localStorage
          this.router.navigate(['dashboard']); // Redireciona para a página do dashboard após o login
        },
        (error) => {
          // Tratar erros de login aqui
          console.error('Falha no login', error);
          // Você pode exibir uma mensagem de erro para o usuário
        }
      );
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
}
