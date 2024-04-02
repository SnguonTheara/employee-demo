import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'employee-component',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent  {

    constructor(
        private jwtHelper: JwtHelperService, private router: Router) {
      }

    public logOut = () => {
        localStorage.removeItem("jwt");
        this.router.navigate(["/login"]);
      }
}
