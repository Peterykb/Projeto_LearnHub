import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './pages/overview/overview.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TeacherGuard } from 'src/app/guards/teacher.guard';
import { RelationCoursesComponent } from './pages/relation-courses/relation-courses.component';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'edit-course',
    pathMatch: 'full',
  },
  {
    path: '',
    component: DashboardComponent,
    children: [
      { path: 'overview', component: OverviewComponent },
      { path: 'my-profile', component: ProfileComponent },
      { path: 'relation-courses', component: RelationCoursesComponent },
      { path: 'edit-course', component: EditCourseComponent },
    ],
    canActivate: [TeacherGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherRoutingModule {}
