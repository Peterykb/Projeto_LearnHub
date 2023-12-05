import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Course } from 'src/app/models/Course';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit{

  categories: Categoria[] = [];
  courses: Course[] = [];
  selectedCategoryName: string = '';

  constructor(private userService: UserService, private router: Router){}

  navigateToCategoriaCursos(categoryId: number, categoryName: string): void {
    this.router.navigate(['/search-result', categoryId]);
    this.selectedCategoryName = categoryName;
  }

  ngOnInit(): void {
    /* Trazendo todas as categorias */
    this.userService.getCategorias().subscribe(data => {
      this.categories = data;
      console.log(this.categories)
    })
  }
  /* CURSOS MAIS ACESSADOS DA PLATAFORMA*/
  coursesAcessed = [
    {
      title: 'Banco de Dados - SQL',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.',
      price: 300,
    },
    {
      title: 'Angular 15+',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.',
      price: 125.55,
    },
    {
      title: 'Chat GPT para Devs',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.',
      price: 150,
    },
    {
      title: 'Robótica Educacional',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.',
      price: 700,
    },
    {
      title: 'AWS - Cloud Fundations',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.',
      price: 450.99,
    },
  ];

}
