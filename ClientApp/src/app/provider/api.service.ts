import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  constructor(private http: HttpClient) { }

  base_url = 'https://localhost:5001/';
  httpHeaders = new HttpHeaders().set(
    'Content-Type', 'application/json'
  );

  persons;
  

  // GET all
  getAll(): Observable<any>
  {
    return this.http.get(this.base_url + 'api/Persons', { headers: this.httpHeaders });
  }
}