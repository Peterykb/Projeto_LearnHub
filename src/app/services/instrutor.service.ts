import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class InstrutorService {
  private baseUrl = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllCourses(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Cursos`);
  }

  getIdProfessor(id: number): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/InstrutorInformacoes/${id}`)
  }


}
