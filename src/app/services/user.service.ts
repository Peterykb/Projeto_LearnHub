import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

private apiUrl = environment.baseApiUrl

  getCategorias(): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/Categorias/Categorias`)
  }
  
  GetCursosdaCategoria(categoryid: number): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/Categorias/Categorias/${categoryid}/Cursos`)
  }

}
