import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoria } from 'src/app/models/Categoria';
import { Course } from 'src/app/models/Course';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  categoriaId: any;
  category!: Categoria[];
  cursos!: any[];
  selectedCategoryName!: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
  ) {}

  // No seu componente de busca
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const categoryIdString = params.get('id');
      const categoryName = params.get('nome');

      if (categoryIdString !== null && categoryName !== null) {
        this.categoriaId = +categoryIdString;
        this.loadCursos();
        this.selectedCategoryName = categoryName;
      }
    });
  }
  /* CURSOS MAIS ACESSADOS DA PLATAFORMA*/
  navigateToCoursePreview(courseId: number): void {
    this.router.navigate(['/course-preview', courseId]);
  }

  loadCursos(): void {
    this.userService
      .GetCursosdaCategoria(this.categoriaId)
      .subscribe((data) => {
        this.cursos = data;
      });
  }
}
