import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './shared/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyCoursesComponent } from './modules/user/my-courses/my-courses.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

import { NgxPaginationModule } from 'ngx-pagination';

import { FooterDefaultComponent } from './components/footer-default/footer-default.component';
import { HeaderDefaultComponent } from './components/header-default/header-default.component';
import { CoursePreviewComponent } from './components/course-preview/course-preview.component';
import { HomeComponent } from './components/home/home.component';
import { MyProfileComponent } from './modules/user/my-profile/my-profile.component';
import { MyCartComponent } from './modules/user/my-cart/my-cart.component';
import { RegisterComponent } from './shared/register/register.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CourseComponent } from './modules/user/course/course.component';
import { BuyComponent } from './modules/user/buy/buy.component';
import { RegisterService } from './services/register.service';
import { SearchComponent } from './components/search/search.component';
import { ChangePassComponent } from './components/change-pass/change-pass.component';
import {HttpClientModule} from '@angular/common/http';
 

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CoursePreviewComponent,
    MyCoursesComponent,
    NotFoundComponent,
    FooterDefaultComponent,
    HeaderDefaultComponent,
    HomeComponent,
    MyProfileComponent,
    MyCartComponent,
    RegisterComponent,
    CourseComponent,
    BuyComponent,
    SearchComponent,
    ChangePassComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    FontAwesomeModule,
    HttpClientModule
  ],
  providers: [RegisterService],
  bootstrap: [AppComponent],
})
export class AppModule {}
