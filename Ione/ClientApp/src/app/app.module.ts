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
import { IoneRouteRoutingModule } from './IoneRoute/ione-route-routing.module';
import { EmpService } from './IoneService/emp.service';
import { LoginService } from './IoneService/login.service';
import { StudentService } from './IoneService/student.service';
import { UserService } from './IoneService/user.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule,
    //  .forRoot([
    //  { path: '', component: HomeComponent, pathMatch: 'full' },
    //  { path: 'counter', component: CounterComponent },
    //  { path: 'fetch-data', component: FetchDataComponent },
    //]),
    IoneRouteRoutingModule
  ],
  providers: [
    EmpService,
    LoginService,
    StudentService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
