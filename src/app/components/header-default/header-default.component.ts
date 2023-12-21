import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/Course';
import { AuthService } from 'src/app/services/auth.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-header-default',
  templateUrl: './header-default.component.html',
  styleUrls: ['./header-default.component.scss']
})
export class HeaderDefaultComponent {
  pesquisar: string = ''
  resultado: Course[] = []
  constructor(private router: Router, public authService: AuthService, private courseservice: CourseService) {}

  mostrarCabRod() {
    return !this.router.url.includes('instrutor') && !this.router.url.includes('login') && !this.router.url.includes('register');
  }

  number = 2
  getcourse(pesquisar: string) {
    this.courseservice.getCourseByName(pesquisar).subscribe(cursos => {
      this.resultado = cursos;
  
      // Serializa a lista de cursos para uma string JSON
      const cursosJSON = JSON.stringify(cursos);
  
      // Navega para a rota 'search-result' e passa a string JSON como parâmetro
      this.router.navigate(['search-result'], { queryParams: { cursos: cursosJSON } });
    });
  }
  

}
