import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from 'src/app/models/Categoria';
import { Course } from 'src/app/models/Course';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  categoriaId: any;
  category!: Categoria[];
  cursos!: any[];

  constructor(private route: ActivatedRoute, private userService: UserService) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const categoryIdString = params.get('id');

      if (categoryIdString !== null) {
        this.categoriaId = +categoryIdString;
        this.loadCursos();
      }
    });
  }

  loadCursos(): void {
    this.userService.GetCursosdaCategoria(this.categoriaId).subscribe(data => {
      this.cursos = data; 
    });
  }
}
