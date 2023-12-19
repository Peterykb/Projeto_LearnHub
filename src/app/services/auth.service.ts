import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiURL = environment.baseApiUrl

  constructor(private router: Router, private http: HttpClient) { }

  setToken(token: string): void{
    localStorage.setItem('token', token)
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  login(credential: {email: string, senha: string}): Observable<any>{
    return this.http.post<any>(`${this.apiURL}/Autentication/login`, credential);
  }

  logout() {
    localStorage.removeItem('token')
    this.router.navigate(['home']);
  }
}
