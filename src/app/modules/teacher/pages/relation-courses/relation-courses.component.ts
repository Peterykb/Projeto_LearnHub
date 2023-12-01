import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-relation-courses',
  templateUrl: './relation-courses.component.html',
  styleUrls: ['./relation-courses.component.scss'],
})
export class RelationCoursesComponent implements OnInit{
  searchQuery = '';

  constructor(){}

  ngOnInit(): void {

  }

  courses = [
    {
      title: 'Curso de Dotnet 7',
      image:
        'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg',
      cat: 1,
      link: './edit-course',
    },
    {
      title: 'Curso de Java Avançado',
      image:
        'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg',
      cat: 1,
    },
    {
      title: 'Angular com .Net 7',
      image:
        'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg',
      cat: 2,
    },
    {
      title: 'Banco de dados - Do Zero ao Avançado',
      image:
        'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg',
      cat: 2,
    },
  ];

  itemsPerPage = 6;
  currentPage = 1;


  get totalPages() {
    return Math.ceil(this.courses.length / this.itemsPerPage);
  }

  get pages() {
    return new Array(this.totalPages).fill(0).map((_, index) => index + 1);
  }

  nextPage() {
    this.currentPage++;
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }
  onInputChange(value: string) {
    this.searchQuery = value.trim();
  }

  clearSearch() {
    this.searchQuery = '';
  }
}
