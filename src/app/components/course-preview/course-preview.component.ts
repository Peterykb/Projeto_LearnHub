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

  cardsData = [
    {
      name_course: 'Curso de React - Do Zero ao Avançado',
      price_course: 200,
      desc_course: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam facere inventore quod iusto dolor perspiciatis reprehenderit officia odio rem? Ex dolores hic, facere quidem enim inventore eos. Fugiat, repellat hic?',
      banner_course: 'https://povio.com/blog/content/images/2023/05/angular-16-banner.jpg'
    },
    {
      name_course: 'Curso de React',
      price_course: 200,
      desc_course: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam facere inventore quod iusto dolor perspiciatis reprehenderit officia odio rem? Ex dolores hic, facere quidem enim inventore eos. Fugiat, repellat hic?',
      banner_course: 'https://povio.com/blog/content/images/2023/05/angular-16-banner.jpg'
    },
    {
      name_course: 'Curso de React',
      price_course: 200,
      desc_course: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam facere inventore quod iusto dolor perspiciatis reprehenderit officia odio rem? Ex dolores hic, facere quidem enim inventore eos. Fugiat, repellat hic?',
      banner_course: 'https://povio.com/blog/content/images/2023/05/angular-16-banner.jpg'
    },
    {
      name_course: 'Curso de React',
      price_course: 200,
      desc_course: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam facere inventore quod iusto dolor perspiciatis reprehenderit officia odio rem? Ex dolores hic, facere quidem enim inventore eos. Fugiat, repellat hic?',
      banner_course: 'https://povio.com/blog/content/images/2023/05/angular-16-banner.jpg'
    },
    {
      name_course: 'Curso de React',
      price_course: 200,
      desc_course: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam facere inventore quod iusto dolor perspiciatis reprehenderit officia odio rem? Ex dolores hic, facere quidem enim inventore eos. Fugiat, repellat hic?',
      banner_course: 'https://povio.com/blog/content/images/2023/05/angular-16-banner.jpg'
    },
  ];


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
