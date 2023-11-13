import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './pages/overview/overview.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TeacherGuard } from 'src/app/guards/teacher.guard';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [ 
      { path: 'overview', component: OverviewComponent },
      { path: 'my-profile', component: ProfileComponent },
    ],
    canActivate: [TeacherGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherRoutingModule {}
