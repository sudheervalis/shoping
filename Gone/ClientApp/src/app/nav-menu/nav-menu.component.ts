import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../GoneService/token.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  

  constructor(private tokenService: TokenService, private router: Router) { }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  title = 'Tasks App';


  isLoggedIn = false;



  ngOnInit() {


    this.isLoggedIn = this.tokenService.isLoggedIn();


  }




  logout(): void {


    this.tokenService.logout();


    this.isLoggedIn = false;


    this.router.navigate(['login']);


    return;


  }

}
