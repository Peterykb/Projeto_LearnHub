import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  courses = [
    {
      title: 'Banco de Dados - SQL',
      desc: 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Unde aspernatur odit quasi maxime labore, rerum earum est magnam commodi doloribus impedit soluta fugiat dolorem consequuntur.'
    },
  ]

  categories = [
    {
      titleCat: 'Front-End',
      class: 'fa-solid fa-desktop text-white',
      descCat: 'Some quick example text to build on the card title and make up the bulk of the cards content.'
    },
    {
      titleCat: 'Back-End',
      class: 'fa-solid fa-server text-white',
      descCat: 'Some quick example text to build on the card title and make up the bulk of the cards content.'
    },
    {
      titleCat: 'Banco de Dados',
      class: 'fa-solid fa-database text-white',
      descCat: 'Some quick example text to build on the card title and make up the bulk of the cards content.'
    },
    {
      titleCat: 'Web Design',
      class: 'fa-solid fa-palette text-white',
      descCat: 'Some quick example text to build on the card title and make up the bulk of the cards content.'
    }
  ]
}
