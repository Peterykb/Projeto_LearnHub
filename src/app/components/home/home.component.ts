import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Course } from 'src/app/models/Course';
import { UserService } from 'src/app/services/user.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit{

  categories: Categoria[] = [];
  courses: Course[] = [];
  selectedCategoryName: string = '';

  constructor(private userService: UserService, private router: Router, private courseService: CourseService){}

// No seu componente home
navigateToCategoriaCursos(categoryId: number, categoryName: string): void {
  this.router.navigate(['/search-result', categoryId, categoryName]);
  this.selectedCategoryName = categoryName;
}


  ngOnInit(): void {
    /* Trazendo todas as categorias */
    this.userService.getCategorias().subscribe(data => {
      this.categories = data;
      console.log(this.categories)
    })

    this.courseService.getCourses().subscribe(data =>{
      this.courses = data
    })
  }

}
