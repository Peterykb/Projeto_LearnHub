import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.scss'],
})
export class BuyComponent {
  dropdown = false;

  creditForm: any;

  constructor(private router: Router, private formBuilder: FormBuilder) {
    this.creditForm = formBuilder.group({
      numero_cartao: ['', Validators.required],
      nome_titular: ['', Validators.required],
      validade: ['', Validators.required],
      codigo_seguranca: ['', Validators.required],
    })
  }

  clickDescription() {
    this.dropdown = !this.dropdown;
  }

  onBuy(){
    if(this.creditForm.valid){
      console.log(this.creditForm.value);
    }
    else{
      alert('FORMULARIO INVALIDO')
    }
  }

  get numero_cartao(){
    return this.creditForm.get('numero_cartao')!
  }

  get nome_titular(){
    return this.creditForm.get('nome_titular')!
  }

  get validade(){
    return this.creditForm.get('validade')!
  }

  get codigo_seguranca(){
    return this.creditForm.get('codigo_seguranca')!
  }

  
  compraEfetuada(){
    alert('Compra efetuada com sucesso!')
  }
}
