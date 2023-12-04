import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }



  criarCurso(cursoData: any): Observable<any> {
    // Simulação de chamada para o backend (simulando um atraso de 1 segundo)
    return of({ message: 'Curso criado com sucesso!', data: cursoData }).pipe(
      delay(1000)
    );
  }
}
