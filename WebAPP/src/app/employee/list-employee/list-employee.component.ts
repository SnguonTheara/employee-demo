import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmployeeService } from '../employee.service';
import { EmployeeQueryFilter } from '../../Models/EmployeQueryFilter';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'list-employee-component',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.scss']
})
export class ListEmployeeComponent  {
    employeeList : any;
    filter: EmployeeQueryFilter = {
        Query: '',
        Page: 1,
        Limit: 15,
        Gender: ''
    };

    constructor(
        private toastr: ToastrService,
        private employeeService: EmployeeService,
        private jwtHelper: JwtHelperService, private router: Router) { 
    }

    ngOnInit() {
        this.getEmployeeListFilter();
    }
    getEmployeeListFilter() {
        this.employeeService.getEmployeeList(this.filter).subscribe(res => {
            this.employeeList = res;  
        });
    }

    exportEmployeeListAsPdf() {
        this.employeeService.getEmployeeListAsPdf(this.filter).subscribe(res => {
            this.employeeList = res;  
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

    deleteEmployee(id: number) {
        if(confirm("Are you sure to delete ")) {
            this.employeeService.deleteEmployee(id).subscribe(res => {
                this.toastr.success("deleted successfully");
                this.getEmployeeListFilter();

            });
          }
    }

    viewEmployee(id: number) {
        this.router.navigateByUrl('/employee/view/' + id);
    }

    editEmployee(id: number) {
        this.router.navigateByUrl('/employee/update/' + id);
    }

}
