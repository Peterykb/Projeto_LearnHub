import { Component } from '@angular/core';

@Component({
  selector: 'app-my-courses',
  templateUrl: './my-courses.component.html',
  styleUrls: ['./my-courses.component.scss']
})
export class MyCoursesComponent {
  courses = [
    {
      title: 'Curso de Dotnet 7',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus reiciendis numquam doloribus reprehenderit in sed culpa facere iste natus eos? Ratione delectus vel aliquam sed culpa nostrum explicabo, recusandae minima!',
      image: 'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg'
    },
    {
      title: 'Curso de Java Avançado',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus reiciendis numquam doloribus reprehenderit in sed culpa facere iste natus eos? Ratione delectus vel aliquam sed culpa nostrum explicabo, recusandae minima!',
      image: 'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg'
    },
    {
      title: 'Angular com .Net 7',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus reiciendis numquam doloribus reprehenderit in sed culpa facere iste natus eos? Ratione delectus vel aliquam sed culpa nostrum explicabo, recusandae minima!',
      image: 'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg'
    },
    {
      title: 'Banco de dados - Do Zero ao Avançado',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus reiciendis numquam doloribus reprehenderit in sed culpa facere iste natus eos? Ratione delectus vel aliquam sed culpa nostrum explicabo, recusandae minima!',
      image: 'https://static.vecteezy.com/ti/fotos-gratis/t2/1349210-paisagem-com-uma-arvore-solitaria-no-lago-foto.jpg'
    },
  ];

  itemsPerPage = 3;
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
