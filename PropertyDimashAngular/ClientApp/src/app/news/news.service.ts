import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { News } from './news';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  BaseUrl: string = "https://localhost:7074/api";
  generateBoundary(): string {
    const chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let boundary = '';
    for (let i = 0; i < 16; i++) {
      boundary += chars[Math.floor(Math.random() * chars.length)];
    }
    return boundary;
  }
  boundary: string = "";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  constructor(private http: HttpClient) { this.boundary = this.generateBoundary(); }

  getNews(): Observable<News[]> {
    return this.http.get<News[]>(this.BaseUrl + '/News').pipe(catchError(this.errorHandler));
  }

  getNewsArticles(id: string): Observable<News> {
    return this.http.get<News>(this.BaseUrl + '/News/' + id).pipe(catchError(this.errorHandler));
  }

  createNews(news: any): Observable<News> {
    return this.http.post<News>(this.BaseUrl + '/News/', JSON.stringify(news), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  editNews(id: string, news: any): Observable<News> {
    return this.http.put<News>(this.BaseUrl + '/News/' + id, JSON.stringify(news), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  deleteNews(id: string): Observable<News> {
    return this.http.delete<News>(this.BaseUrl + '/News/' + id, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = error.message;// 'Error code ${error.status}\nMessage ${error.message}';
    }
    return throwError(errorMessage);
  }
}
