import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './shared/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/home/home.component';
import { MyProfileComponent } from './modules/user/my-profile/my-profile.component';
import { CoursePreviewComponent } from './components/course-preview/course-preview.component';
import { MyCartComponent } from './modules/user/my-cart/my-cart.component';
import { MyCoursesComponent } from './modules/user/my-courses/my-courses.component';
import { RegisterComponent } from './shared/register/register.component';
import { DashboardComponent } from './modules/teacher/dashboard/dashboard.component';
import { TeacherModule } from './modules/teacher/teacher.module';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'dashboard-teacher', component: DashboardComponent},
  { path: 'course-preview', component: CoursePreviewComponent },
  { path: 'my-cart', component: MyCartComponent },
  { path: 'my-courses', component: MyCoursesComponent },
  { path: 'profile', component: MyProfileComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule, TeacherModule],
})
export class AppRoutingModule {}
