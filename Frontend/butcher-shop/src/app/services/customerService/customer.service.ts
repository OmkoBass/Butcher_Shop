import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  url = 'https://localhost:44323/api/Customer'

  constructor(private http: HttpClient) { }

  GetCustomer(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.get<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  CreteCustomer(butcherStoreId: string, articleId: string, customer) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.post<any>(`${this.url}/:butcherStore/:articleId?butcherStoreId=${butcherStoreId}&articleId=${articleId}`, customer, { headers });
  }

  DeleteCustomer(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.delete<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  UpdateCustomer(id: string, customer) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.put<any>(`${this.url}/:id?Id=${id}`, customer, { headers });
  }
}
