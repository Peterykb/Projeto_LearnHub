import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.scss'],
})
export class BuyComponent {
  dropdown = false;

  constructor(private router: Router) {}

  clickDescription() {
    this.dropdown = !this.dropdown;
  }

  confirmPix() {
    const data = prompt(
      'Digite esse pix aqui para a transferência: \n(00)00000-0000'
    );

    if (data === null || data.length == 0) {
      alert('Digite o pix para efetuar a compra!');
    } else {
      alert('Verificado!');
    }
  }
  
  compraEfetuada(){
    alert('Compra efetuada com sucesso!')
    this.router.navigate(['my-courses'])
  }
}
