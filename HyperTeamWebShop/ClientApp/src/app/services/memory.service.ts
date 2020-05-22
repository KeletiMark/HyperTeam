import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Memory } from '../models/memory';

@Injectable({
  providedIn: 'root'
})
export class MemoryService {

  private url: string = this.baseUrl + "memory";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<Memory[]> {
    return this.http.get<Memory[]>(this.url);
  }

  getById(id: number): Observable<Memory> {
    const url = `${this.url}/${id}`;
    return this.http.get<Memory>(url);
  }

  insert(memory: Memory): Observable<Memory> {
    return this.http.post<Memory>(this.url, memory, this.httpOptions);
  }

  update(memory: Memory): Observable<Memory> {
    return this.http.put<Memory>(this.url, memory, this.httpOptions)
  }

  delete(id: number): Observable<Memory> {
    const url = `${this.url}/${id}`;
    return this.http.delete<Memory>(url, this.httpOptions);
  }
}
