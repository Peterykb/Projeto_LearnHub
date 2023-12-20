import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiURL = environment.baseApiUrl;
  private jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(private http: HttpClient, private router: Router) { }

  setToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  login(credential: { email: string, senha: string }): Observable<any> {
    return this.http.post<any>(`${this.apiURL}/Autentication/login`, credential);
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/home'])
  }
  isLoggedIn(){
    return this.getToken();
  }

  decodeToken(): any {
    const token = this.getToken();
    if (token) {
      return this.jwtHelper.decodeToken(token);
    }
    return null;
  }
}

