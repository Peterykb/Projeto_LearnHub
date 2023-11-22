import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { OverviewComponent } from './pages/overview/overview.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RelationCoursesComponent } from './pages/relation-courses/relation-courses.component';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';

@NgModule({
  declarations: [
    DashboardComponent,
    OverviewComponent,
    ProfileComponent,
    RelationCoursesComponent,
    EditCourseComponent,
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule
  ]
})
export class TeacherModule { }
