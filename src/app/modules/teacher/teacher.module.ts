import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { OverviewComponent } from './pages/overview/overview.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RelationCoursesComponent } from './pages/relation-courses/relation-courses.component';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';
import { StudentsComponent } from './pages/students/students.component';
import { StudentsTableComponent } from './pages/students-table/students-table.component';
import { CreateCourseComponent } from './pages/create-course/create-course.component';
import { FormsModule } from '@angular/forms';
  

@NgModule({
  declarations: [
    DashboardComponent,
    OverviewComponent,
    ProfileComponent,
    RelationCoursesComponent,
    EditCourseComponent,
    StudentsComponent,
    StudentsTableComponent,
    CreateCourseComponent,
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    FormsModule,
  ]
})
export class TeacherModule { }
