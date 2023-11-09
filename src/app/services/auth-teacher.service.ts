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
    return this.auth.getToken() === "ProfessorLogado";
  }


  loginTeacher({email, password}: any): Observable<any>{
    if(email === 'teacher@email.com' && password === '12345678'){
      this.auth.setToken('ProfessorLogado')
      return of({name: 'João Guilherme', email: 'teacher@email.com'})
    }
    return throwError(new Error('Falha no login'))
  }
}
