import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmployeeService } from '../employee.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Employee } from '../../Models/Employee';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'create-employee-component',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.scss']
})
export class CreateEmployeeComponent  { 
    employeeForm: any;
    constructor(
        private toastr: ToastrService,
        private formbulider: FormBuilder,
        private employeeService: EmployeeService,
        private jwtHelper: JwtHelperService, private router: Router) { 
    }

    ngOnInit() {
        this.employeeForm = this.formbulider.group({
          employeeId: ['', [Validators.required]],
          fullName: ['', [Validators.required]],
          gender: ['', [Validators.required]],
          birthDay: ['', [Validators.required]]
        });
      }

      createEmployee(employee: Employee) {
        this.employeeService.createEmployee(employee).subscribe(res => {
            console.log(res);
            this.toastr.success("created successfully");
            this.router.navigateByUrl('/employee');
        });
      }
}