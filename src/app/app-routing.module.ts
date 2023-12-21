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
import { TeacherModule } from './modules/teacher/teacher.module';
import { UserGuard } from './guards/user.guard';
import { TeacherGuard } from './guards/teacher.guard';
import { BlockGuard } from './guards/block.guard';
import { CourseComponent } from './modules/user/course/course.component';
import { BuyComponent } from './modules/user/buy/buy.component';
import { SearchComponent } from './components/search/search.component';
import { ChangePassComponent } from './components/change-pass/change-pass.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent},
  { path: 'search-result/:id/:nome', component: SearchComponent, canActivate:[BlockGuard]},
  { path: 'login', component: LoginComponent, canActivate: [BlockGuard]},
  { path: 'register', component: RegisterComponent, canActivate: [BlockGuard] },
  { path: 'course-preview/:name', component: CoursePreviewComponent },
  { path: 'user/my-cart', component: MyCartComponent, canActivate: [UserGuard] },
  { path: 'user/buy', component: BuyComponent, canActivate: [UserGuard] },
  {
    path: 'user/my-courses',
    component: MyCoursesComponent,
    canActivate: [UserGuard],
  },
  {
    path: 'user/course',
    component: CourseComponent,
    canActivate: [UserGuard],
  },
  { path: 'user/profile', component: MyProfileComponent, canActivate: [UserGuard] },
  { path: 'user/profile/change-pass', component: ChangePassComponent, canActivate: [UserGuard] },
  {
    path: 'instrutor/:id',
    canActivate: [TeacherGuard],
    loadChildren: () =>
    import('./modules/teacher/teacher.module').then((m) => m.TeacherModule),
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule,  TeacherModule],
})
export class AppRoutingModule {}
