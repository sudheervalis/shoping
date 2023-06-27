import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmpComponent } from '../emp/emp.component';
import { StudentComponent } from '../student/student.component';
import { UserComponent } from '../user/user.component';
import { LoginComponent } from '../login/login.component';
import { ProfileComponent } from '../login/profile/profile.component';
import { AuthGuard } from '../GoneService/helpers/auth.guard';
import { SignupComponent } from '../login/signup/signup.component';
import { TasksComponent } from '../tasks/tasks.component';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { HomeComponent } from '../home/home.component';





const routes: Routes = [
  //{ path: '', component: EmpComponent, pathMatch: 'full' },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'Emp', component: EmpComponent,  canActivate: [AuthGuard] },
  { path: 'Student', component: StudentComponent, canActivate: [AuthGuard] },
  { path: 'User', component: UserComponent ,canActivate: [AuthGuard]},
  { path: 'home', component: HomeComponent , canActivate: [AuthGuard] },
  //{ path: 'tasks', component: TasksComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent ,canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  //{ path: '', redirectTo: 'tasks', pathMatch: 'full' }

]
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class GoneRouteRoutingModule { }
