import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl, FormGroup } from '@angular/forms';
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
      senha: ['', [Validators.required, Validators.minLength(8)]],
    });
  }
  ngOnInit(): void {
  }

  onSubmit() {
   
    if (this.loginForm.valid) {
      const credentials = {
        email:  this.loginForm.get('email')!.value,
        senha: this.loginForm.get('senha')!.value
      };

      this.authService.login(credentials).subscribe(
        (response) => {
          // Tratar a resposta do login bem-sucedido aqui
          console.log('Login bem-sucedido', response);
          this.authService.setToken(response.token); 
          this.router.navigate(['home']); 
        },
        (error) => {
          // Tratar erros de login aqui
          console.error('Falha no login', error);
          // Exibir mensagem de erro para o usuário, se necessário
        }
      );
    }
  }

  passShow(){
    this.showPass = !this.showPass;
  }



}
