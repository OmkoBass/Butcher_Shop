import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ButcherStoreService {
  url = 'https://localhost:44323/api/ButcherStore';

  constructor(private http: HttpClient) { }

  CreateButcherStore(butcherStore: any) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.post<any>(this.url, butcherStore, { headers });
  }

  DeleteButcherStore(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.delete<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  GetButcherStore(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.get<any>(`${this.url}/:id?Id=${id}`, { headers });
  }
}
