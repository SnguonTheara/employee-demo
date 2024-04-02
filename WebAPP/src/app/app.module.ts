import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './guards/auth-guard.service';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { ToastrModule } from 'ngx-toastr';
import { ListEmployeeComponent } from './employee/list-employee/list-employee.component';
import { EmployeeComponent } from './employee/employee.component';
import { CreateEmployeeComponent } from './employee/create-employee/create-employee.component';
import { UpdateEmployeeComponent } from './employee/update-employee/update-employee.component';
import { GenderPipe } from './pipe/gender.pipe';
import { ViewEmployeeComponent } from './employee/view-employee/view-employee.component';

//all components routes
const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'product', component: ProductsComponent, canActivate: [AuthGuard] },
  { 
    path: 'employee', 
    component: EmployeeComponent, 
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ListEmployeeComponent },
      {path: 'view/:id', component: ViewEmployeeComponent},
      { path: 'update/:id', component: UpdateEmployeeComponent },
      { path: 'create', component: CreateEmployeeComponent },
    ]
  },
  { path: 'login', component: LoginComponent },
];

//function is use to get jwt token from local storage
export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    GenderPipe,
    AppComponent,
    EmployeeComponent,
    UpdateEmployeeComponent,
    CreateEmployeeComponent,
    ListEmployeeComponent,
    ProductsComponent,
    HomepageComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7299"],
        disallowedRoutes: []
      }
  }),
  ToastrModule.forRoot()
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
