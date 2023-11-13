import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthTeacherService {

  constructor(private router: Router) { }

  setToken(token: string): void{
    localStorage.setItem('token', token)
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn() {
    return this.getToken() === "ProfessorLogado";
  }

  logout() {
    localStorage.removeItem('token')
    this.router.navigate(['home']);
  }

  loginTeacher({email, password}: any): Observable<any>{
    if(email === 'teacher@email.com' && password === '12345678'){
      this.setToken('ProfessorLogado')
      return of({name: 'João Guilherme', email: 'teacher@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
