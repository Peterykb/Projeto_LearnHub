import { Component } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent {
  courses = [
    {
      title: 'Curso de Dotnet 7',
      image:
        'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg',
      cat: 1,
      link: './students'
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
}
