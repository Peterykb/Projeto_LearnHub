import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthTeacherService {

  constructor(private router: Router, private auth: AuthService) { }

  isLoggedIn() {
    const token = this.auth.getToken()
    return token ? token.trim().toLowerCase() === 'professorlogado' : false;

  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token')
    this.router.navigate(['home']);
  }

  loginTeacher({email, password}: any): Observable<any>{
    if(email === 'professor@professor.com' && password === '12345678'){
      this.auth.setToken('professorlogado')

      return of({name: 'João Guilherme', email: 'teacher@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
