import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { LoginCredentials } from 'src/app/interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})
export class ButcherService {
  authUrl = 'https://localhost:44323/authenticate'; 
  url = 'https://localhost:44323/api/Butcher';

  constructor(private http: HttpClient, private router: Router) { }

  LoginButcher(credentials: LoginCredentials) {
    return this.http.post<any>(this.authUrl, credentials);
  }

  GetButcher() {
    let headers = new HttpHeaders().set('Authorization', localStorage.getItem('beefyToken') || '');

    return this.http.get<any>(`${this.url}/loggedIn`, { headers });
  }

  handleLogOut() {
    localStorage.removeItem('beefyToken');
    this.router.navigate(['/login']);
  }
}
