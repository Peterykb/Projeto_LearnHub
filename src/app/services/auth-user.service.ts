import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthUserService {

  constructor(private router: Router, private auth: AuthService) { }

  isLoggedIn() {
    return this.auth.getToken() === "UsuarioLogado";
  }


  login({email, password}: any): Observable<any>{
    if(email === 'email@email.com' && password === '12345678'){
      this.auth.setToken('UsuarioLogado')
      return of({name: 'João Guilherme', email: 'email@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
