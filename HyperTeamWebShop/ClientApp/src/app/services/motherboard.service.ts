import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Motherboard } from '../models/motherboard';

@Injectable({
  providedIn: 'root'
})
export class MotherboardService {

  private url: string = this.baseUrl + "motherboard";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<Motherboard[]> {
    return this.http.get<Motherboard[]>(this.url);
  }

  getById(id: number): Observable<Motherboard> {
    const url = `${this.url}/${id}`;
    return this.http.get<Motherboard>(url);
  }

  insert(motherboard: Motherboard): Observable<Motherboard> {
    return this.http.post<Motherboard>(this.url, motherboard, this.httpOptions);
  }

  update(motherboard: Motherboard): Observable<Motherboard> {
    return this.http.put<Motherboard>(this.url, motherboard, this.httpOptions)
  }

  delete(id: number): Observable<Motherboard> {
    const url = `${this.url}/${id}`;
    return this.http.delete<Motherboard>(url, this.httpOptions);
  }

}
