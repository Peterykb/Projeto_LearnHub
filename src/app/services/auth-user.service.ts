import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthUserService {

  constructor(private router: Router) { }

  setToken(token: string): void{
    localStorage.setItem('token', token)
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn() {
    return this.getToken() === "UsuarioLogado";
  }

  logout() {
    localStorage.removeItem('token')
    this.router.navigate(['home']);
  }

  login({email, password}: any): Observable<any>{
    if(email === 'email@email.com' && password === '12345678'){
      this.setToken('UsuarioLogado')

      return of({name: 'João Guilherme', email: 'email@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
