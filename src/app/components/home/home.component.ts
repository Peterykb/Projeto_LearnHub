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
    }
  ]
}
