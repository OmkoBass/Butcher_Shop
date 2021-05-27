import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = 'https://localhost:44323/api/Employee'

  constructor(private http: HttpClient) { }

  CreateEmployee(employee) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.post<any>(this.url, employee, { headers });
  }

  DeleteEmployee(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.delete<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  UpdateEmployee(id: string, employee) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.put<any>(`${this.url}/:id?Id=${id}`, employee, { headers });
  }

  GetEmployeesForButcherStore() {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.get<any>(`${this.url}/all`, { headers });
  }
}
