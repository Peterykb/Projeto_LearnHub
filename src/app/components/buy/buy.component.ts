import { Component } from '@angular/core';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.scss']
})
export class BuyComponent {
  dropdown = false

  clickDescription(){
    this.dropdown = !this.dropdown
  }
}
