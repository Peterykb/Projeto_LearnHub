import { Component } from '@angular/core';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent {
  dropdown = false

  clickDescription(){
    this.dropdown = !this.dropdown
  }

  autoSize(event: Event) {
    const target = event.target as HTMLTextAreaElement;
    if (target) {
      target.style.height = 'auto';
      target.style.height = (target.scrollHeight) + 'px';
    }
  }
  
}
