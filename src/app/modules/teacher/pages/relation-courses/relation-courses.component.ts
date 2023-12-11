import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/Course';
import { InstrutorService } from 'src/app/services/instrutor.service';

@Component({
  selector: 'app-relation-courses',
  templateUrl: './relation-courses.component.html',
  styleUrls: ['./relation-courses.component.scss'],
})
export class RelationCoursesComponent implements OnInit{
  searchQuery = '';
  courses!: Course[];

  constructor(private instrutor: InstrutorService){}

  ngOnInit(): void {
    this.instrutor.getAllCourses().subscribe(data =>{
      this.courses = data
    })
  }

  itemsPerPage = 6;
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
  onInputChange(value: string) {
    this.searchQuery = value.trim();
  }

  clearSearch() {
    this.searchQuery = '';
  }
}
