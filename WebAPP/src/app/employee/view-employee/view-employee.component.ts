import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmployeeService } from '../employee.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Employee } from '../../Models/Employee';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'view-employee-component',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.scss']
})
export class ViewEmployeeComponent  { 
    employee: any;
    
    constructor(
        private router: Router,
        public activatedRoute: ActivatedRoute,
        private formbulider: FormBuilder,
        private employeeService: EmployeeService,
        private jwtHelper: JwtHelperService, private route: ActivatedRoute) { 
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.employeeService.viewEmployee(params['id']).subscribe(res => {
                this.employee = res;
            });   
        });
      }
      deleteEmployee(id: number) {
        if(confirm("Are you sure to delete ")) {
            this.employeeService.deleteEmployee(id).subscribe(res => {
                this.router.navigateByUrl('/employee');
            });
          }
    }

    back() {
        this.router.navigateByUrl('/employee');
    }
     
}