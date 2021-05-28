import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  url = 'https://localhost:44323/api/Article'

  constructor(private http: HttpClient) { }

  CreateArticle(article) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.post<any>(this.url, article, { headers });
  }

  DeleteArticle(id: string) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.delete<any>(`${this.url}/:id?Id=${id}`, { headers });
  }

  UpdateAritcle(id: string, article) {
    let headers = new HttpHeaders().set("Authorization", localStorage.getItem('beefyToken'));

    return this.http.put<any>(`${this.url}/:id?Id=${id}`, article, { headers });
  }
}
