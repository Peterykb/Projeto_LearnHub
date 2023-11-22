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
    const token = this.auth.getToken()
    return token ? token.trim().toLowerCase() === 'usuariologado' : false;

  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }


  logout() {
    localStorage.removeItem('token')
    this.router.navigate(['home']);
  }

  login({email, password}: any): Observable<any>{
    if(email === 'aluno@aluno.com' && password === '12345678'){
      this.auth.setToken('usuariologado')

      return of({name: 'João Guilherme', email: 'email@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
