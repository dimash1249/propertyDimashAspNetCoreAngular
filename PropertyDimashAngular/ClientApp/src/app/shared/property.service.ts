import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, of, throwError } from 'rxjs';
import { Flat } from '../property/flat';
import { House } from '../property/house';
import { Property } from '../property/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  private apiUrl = "https://localhost:7074/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, OPTIONS',
      'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Requested-With, Accept, Authorization'
    })
  };
 
  constructor(private http: HttpClient) {
  }

  getProperties(): Observable<Property[]> {

    return this.http.get<Property[]>(this.apiUrl + '/Property').pipe(catchError(this.errorHandler));
  }

  getProperty(id: string | undefined): Observable<Property> {

    return this.http.get<Property>(this.apiUrl + '/Property/' + id).pipe(catchError(this.errorHandler));
  }

  createPropertyFlat(property: any): Observable<Property> {
    console.log(property)
    return this.http.post<Property>(this.apiUrl + '/Property/Flat', JSON.stringify(property), this.httpOptions).pipe(catchError(this.errorHandler));
  }

  createPropertyHouse(property: any): Observable<Property> {
    return this.http.post<Property>(this.apiUrl + '/Property/House', property);
  }

  deleteProperty(id: string) {

    return this.http.delete<Property>(this.apiUrl + '/Property/' + id, this.httpOptions).pipe(catchError(this.errorHandler));
  }
  pricePredictionOfProperty(property: any): Observable<any> {
    console.log(property)
    return this.http.post<any>('http://localhost:5000/api/price-prediction-of-house', JSON.stringify(property), this.httpOptions).pipe(catchError(this.errorHandler));
  }
  errorHandler(error: any) {

    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {

      errorMessage = error.error.message;
    } else {

      errorMessage = error.message;//'Error Code: ${error.status}\nMessage: ${error.message}';
    }
    return throwError(errorMessage);
  }
}

