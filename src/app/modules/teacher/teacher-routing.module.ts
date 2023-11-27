import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './pages/overview/overview.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TeacherGuard } from 'src/app/guards/teacher.guard';
import { RelationCoursesComponent } from './pages/relation-courses/relation-courses.component';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';
import { StudentsComponent } from './pages/students/students.component';
import { StudentsTableComponent } from './pages/students-table/students-table.component';
import { CreateCourseComponent } from './pages/create-course/create-course.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'relation-courses/edit-course',
    pathMatch: 'full',
  },
  {
    path: '',
    component: DashboardComponent,
    children: [
      { path: 'overview', component: OverviewComponent },
      { path: 'my-profile', component: ProfileComponent },
      { path: 'relation-courses', component: RelationCoursesComponent },
      { path: 'relation-courses/create-course', component: CreateCourseComponent },
      { path: 'relation-courses/edit-course', component: EditCourseComponent },
      { path: 'relation-students', component: StudentsComponent },
      { path: 'relation-students/students', component: StudentsTableComponent },
    ],
    canActivate: [TeacherGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherRoutingModule {}
