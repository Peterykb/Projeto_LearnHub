import { Component } from '@angular/core';

@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.scss']
})
export class MyCartComponent {
  number = 2;

  courses = [
    {
      name: 'Banco de Dados - SQL',
      prof: 'Guilherme Souza',
      carga: '100h',
      preco: 200,
      avaliacao: 3000,
      curtidas: 1000
    },
    {
      name: 'Banco de Dados - SQL',
      prof: 'Guilherme Souza',
      carga: '100h',
      preco: 200,
      avaliacao: 3000,
      curtidas: 1000
    },
    {
      name: 'Banco de Dados - SQL',
      prof: 'Guilherme Souza',
      carga: '100h',
      preco: 200,
      avaliacao: 3000,
      curtidas: 1000
    },
    {
      name: 'Banco de Dados - SQL',
      prof: 'Guilherme Souza',
      carga: '100h',
      preco: 200,
      avaliacao: 3000,
      curtidas: 1000
    },
  ]
}
