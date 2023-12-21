import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Course } from '../models/Course';


@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private baseURL = environment.baseApiUrl

  constructor(private http: HttpClient) { }

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(`${this.baseURL}/Cursos`)
  }

  // Obter detalhes de um curso por ID
  getCourseByName(courseName: string): Observable<any> {
    return this.http.get<any  >(`${this.baseURL}/Cursos/${courseName}`)
  }

  createCourse(course: Course): Observable<Course>{
    return this.http.post<Course>(`${this.baseURL}/Cursos`, course);
  }
}
