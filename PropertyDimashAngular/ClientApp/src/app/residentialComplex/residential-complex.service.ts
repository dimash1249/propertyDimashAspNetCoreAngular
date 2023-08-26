import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ResidentialComplex } from './residential-complex';

@Injectable({
  providedIn: 'root'
})
export class ResidentialComplexService {
  BaseUrl: string = "https://localhost:7074/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  getResidentialComplexes(): Observable<ResidentialComplex[]> {
    return this.http.get<ResidentialComplex[]>(this.BaseUrl + '/ResidentialComplex').pipe(catchError(this.errorHandler));
  }

  getResidentialComplex(id: string): Observable<ResidentialComplex> {
    return this.http.get<ResidentialComplex>(this.BaseUrl + '/ResidentialComplex/' + id).pipe(catchError(this.errorHandler));
  }

  createResidentialComplex(residentialComplex: any): Observable<ResidentialComplex> {
    return this.http.post<ResidentialComplex>(this.BaseUrl + '/ResidentialComplex/', JSON.stringify(residentialComplex), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  deleteResidentialComplex(id: string): Observable<ResidentialComplex> {
    return this.http.delete<ResidentialComplex>(this.BaseUrl + '/ResidentialComplex/' + id, this.httpOptions).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = 'Error code ${error.status}\nMessage ${error.message';
    }
    return throwError(errorMessage);
  }
}
