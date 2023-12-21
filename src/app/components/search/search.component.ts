import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/Course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  cursos: Course[] = [];
  nomeCurso: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private courseservice: CourseService
  ) {}

  ngOnInit(): void {
    // Captura o parâmetro 'cursos' da URL (agora usando queryParams)
    this.route.queryParams.subscribe(params => {
      const cursosJSON = params['cursos'];

      // Verifica se há uma string JSON válida
      if (cursosJSON) {
        // Deserializa a string JSON para a lista de cursos
        this.cursos = JSON.parse(cursosJSON);
      } else {
        console.warn('Nenhum parâmetro de cursos fornecido na URL.');
      }
    });
  }

  navigateToCoursePreview(courseId: number): void {
    this.router.navigate(['/course-preview', courseId]);
  }
}
