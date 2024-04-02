import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmployeeService } from '../employee.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Employee } from '../../Models/Employee';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'update-employee-component',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.scss']
})
export class UpdateEmployeeComponent  { 
    employeeForm: any;
    employee: any;

    constructor(
        private toastr: ToastrService,
        private route: ActivatedRoute,
        private formbulider: FormBuilder,
        private employeeService: EmployeeService,
        private jwtHelper: JwtHelperService, 
        private router: Router) { 
    }
    ngOnInit() {     
    
        this.route.params.subscribe(params => {
            this.employeeService.viewEmployee(params['id']).subscribe(res => {
                this.employee = res;
                this.employeeForm = this.formbulider.group({
                    employeeId: [this.employee.employeeId, [Validators.required]],
                    fullName: [this.employee.fullName, [Validators.required]],
                    gender: [this.employee.gender, [Validators.required]],
                    birthDay: [this.employee.birthDay, [Validators.required]]
                  });
            });   
        });
      }

    updateEmployee(employee: Employee) {
        employee.id = this.employee.id;
        this.employeeService.updateEmployee(employee).subscribe(res => {
            console.log("res", res);
            this.toastr.success("updated successfully");
            this.router.navigateByUrl('/employee');
        });   
    }
}