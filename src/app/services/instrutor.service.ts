import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class BackendService {
  private baseUrl = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/instrutor/`);
  }

}
