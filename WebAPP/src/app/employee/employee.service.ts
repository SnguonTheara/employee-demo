import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import configurl from '../../assets/config/config.json'
import { Employee } from '../Models/Employee';
import { ResponsePaginate } from '../Models/ResponsePaginate';
import { EmployeeQueryFilter } from '../Models/EmployeQueryFilter';
import { Dashboard } from '../Models/Dashboard';
import { HttpResponse } from '../Models/Response';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
    private url = configurl.apiServer.url + '/api/';
    constructor(private http: HttpClient) { }

    getDashboard(): Observable<HttpResponse<Dashboard>>
    {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            })
        };
        return this.http.get<HttpResponse<Dashboard>>(`${this.url}Dashboard`, httpHeaders);
    }
    getEmployeeList(filter: EmployeeQueryFilter): Observable<ResponsePaginate<Employee[]>> 
    {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }),
            params: new HttpParams()
                .set('Query', filter.Query ?? '')
                .set('Page', filter.Page ?? 1)
                .set('Limit', filter.Limit ?? 15)
        };
        return this.http.get<ResponsePaginate<Employee[]>>(this.url + 'Employee/', httpHeaders);
    }
    getEmployeeListAsPdf(filter: EmployeeQueryFilter): Observable<ResponsePaginate<Employee[]>> {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }),
            params: new HttpParams()
                .set('Query', filter.Query ?? '')
                .set('Page', filter.Page ?? 1)
                .set('Limit', filter.Limit ?? 15)
        };
        return this.http.get<ResponsePaginate<Employee[]>>(this.url + 'Employee/Export-pdf', httpHeaders);
    } 
    createEmployee(data: Employee): Observable<Employee> {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            })
        };
        return this.http.post<Employee>(this.url + 'Employee/', data, httpHeaders);
    }

    updateEmployee(data: Employee): Observable<Employee> {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            })
        };
        return this.http.put<Employee>(this.url + 'Employee/' + data.id, data, httpHeaders);
    }
    deleteEmployee(id: number): Observable<HttpResponse<any>> {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            })
        };
        return this.http.delete(this.url + 'Employee/' + id, httpHeaders);
    }

    viewEmployee(id: number): Observable<HttpResponse<Employee>> {
        const token = localStorage.getItem("jwt");
        const httpHeaders = { 
            headers:new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            })
        };
        return this.http.get(this.url + 'Employee/' + id, httpHeaders);
    }
}