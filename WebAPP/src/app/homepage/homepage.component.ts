import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmployeeService } from '../employee/employee.service';
import { Dashboard } from '../Models/Dashboard';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent  {

  dashboard: any;
  constructor(
    private employeeService: EmployeeService,
    private jwtHelper: JwtHelperService, private router: Router) {
  }

  ngOnInit() {
    this.employeeService.getDashboard().subscribe(res => {
      this.dashboard = res.data;
    });
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
  }

}
