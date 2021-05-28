import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {
  url = 'https://localhost:44323/api/Storage'

  constructor(private http: HttpClient) { }

  GetStorageById(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.get<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  CreateStorage(storage) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.post<any>(this.url, storage, { headers });
  }

  DeleteStorage(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.delete<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  UpdateStorage(id: string, storage) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.put<any>(`${this.url}/:id?Id=${id}`, storage, { headers });
  }
}
