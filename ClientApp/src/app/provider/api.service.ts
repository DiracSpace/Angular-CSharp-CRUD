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
  
  // GET all
  getAll(): Observable<any>
  {
    return this.http.get(this.base_url + 'api/Persons', { headers: this.httpHeaders });
  }

  // GET certain Id
  getPersonById(id: any): Observable<any>
  {
    return this.http.get(this.base_url + `api/Persons/${ id }`, { headers: this.httpHeaders });
  }

  // PUT person
  updatePerson(person: any): Observable<any>
  {
    return this.http.put(this.base_url + `api/Persons/${ person.id }`, person, { headers: this.httpHeaders });
  }

  // POST un estudiante
  registerPerson(person: any): Observable<any>
  {
    return this.http.post(this.base_url + 'api/Persons', person, { headers: this.httpHeaders });
  }

  // DELETE un estudiante
  erasePerson(id: any): Observable<any>
  {
    return this.http.delete(this.base_url + `api/Persons/${ id }`, { headers: this.httpHeaders });
  }
}