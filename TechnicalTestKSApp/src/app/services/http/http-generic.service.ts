import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class HttpGenericService {

  constructor(private http: HttpClient) { }

  apiUrl: string = environment.apiUrl;
  
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "*",
      "Access-Control-Allow-Headers": "*"
    }),
  };

  get<R>(endpoint: string): Observable<R> {
    return this.http
      .get<R>(this.apiUrl + endpoint, this.httpOptions);
  }
  getById<R>(endpoint: string, id: string): Observable<R> {
    return this.http
      .get<R>(this.apiUrl + endpoint.replace('{id}', id), this.httpOptions);
  }
  post<R,T>(endpoint: string, body: T): Observable<R> {
    return this.http
     .post<R>(this.apiUrl + endpoint, body, this.httpOptions);
  }
  put<R,T>(endpoint: string, body: T): Observable<R> {
    return this.http
     .put<R>(this.apiUrl + endpoint, body, this.httpOptions);
  }
  delete<R>(endpoint: string, id: number): Observable<R> {
    const idString: string = id.toString()
    return this.http
      .delete<R>(this.apiUrl + endpoint.replace('{id}', idString), this.httpOptions);
  }
}
