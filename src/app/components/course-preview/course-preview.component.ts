import { Component,ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthUserService } from 'src/app/services/auth-user.service';

@Component({
  selector: 'app-course-preview',
  templateUrl: './course-preview.component.html',
  styleUrls: ['./course-preview.component.scss']
})
export class CoursePreviewComponent {

  @ViewChild('carousel') carousel!: ElementRef;
  @ViewChild('cards') cards!: ElementRef;

  constructor(private router: Router, private userService: AuthUserService){}

  images =[
    'https://services.meteored.com/img/article/inteligencia-artificial-aprende-a-reconstruir-imagens-vistas-por-pessoas-ciencia-fotos-1679175318563_768.jpg',
    'https://services.meteored.com/img/article/inteligencia-artificial-aprende-a-reconstruir-imagens-vistas-por-pessoas-ciencia-fotos-1679175318563_768.jpg',
    'https://services.meteored.com/img/article/inteligencia-artificial-aprende-a-reconstruir-imagens-vistas-por-pessoas-ciencia-fotos-1679175318563_768.jpg',
  ]

  cardsData: string[] = ['Card 1', 'Card 2', 'Card 3','Card 3','Card 3','Card 3','Card 3','Card 3','Card 3']; // Replace with your card data


  verifyBuy(){
    if(!this.userService.isLoggedIn()){
      this.router.navigate(['login'])
    } else{
      this.router.navigate(['buy'])
    }
  }

  ngAfterViewInit(): void {
    this.adjustCarouselWidth();
  }

  adjustCarouselWidth(): void {
    const cardWidth = this.cards.nativeElement.querySelector('.card').offsetWidth;
    const cardsCount = this.cards.nativeElement.querySelectorAll('.card').length;
    const cardsWrapperWidth = cardWidth * cardsCount;
    this.cards.nativeElement.style.width = `${cardsWrapperWidth}px`;
  }

  moveCarousel(direction: 'prev' | 'next'): void {
    const carousel = this.carousel.nativeElement;
    const cardWidth = this.cards.nativeElement.querySelector('.card').offsetWidth;
    const cardsWrapperWidth = parseFloat(this.cards.nativeElement.style.width);
    let translateValue = parseFloat(getComputedStyle(carousel).getPropertyValue('transform').split(',')[4]) || 0;

    if (direction === 'next' && translateValue > -(cardsWrapperWidth - carousel.offsetWidth)) {
      translateValue -= cardWidth;
      carousel.style.transform = `translateX(${translateValue}px)`;
    }

    if (direction === 'prev' && translateValue < 0) {
      translateValue += cardWidth;
      carousel.style.transform = `translateX(${translateValue}px)`;
    }
  }
}
