import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  url = 'https://localhost:44323/api';

  constructor(private http: HttpClient) { }

  GetCompleteButcherStores() {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.get<any>(`${this.url}/ButcherStore/complete/butcherStores`, { headers });
  }
}
