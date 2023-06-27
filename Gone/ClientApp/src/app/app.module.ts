import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { GoneRouteRoutingModule } from './GoneRouter/gone-route-routing.module';
import { EmpComponent } from './emp/emp.component';
import { StudentComponent } from './student/student.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptorProvider } from './GoneService/interceptors/auth.interceptor';
import { ErrorInterceptorProvider } from './GoneService/interceptors/error.interceptor';
import { TasksComponent } from './tasks/tasks.component';
import { SignupComponent } from './login/signup/signup.component';
import { ProfileComponent } from './login/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmpComponent,
    StudentComponent,
    UserComponent,
    LoginComponent,
    TasksComponent,
    SignupComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule,
    GoneRouteRoutingModule
  ],
  providers: [


    AuthInterceptorProvider,


    ErrorInterceptorProvider


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
