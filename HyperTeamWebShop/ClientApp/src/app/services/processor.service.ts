import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Processor } from '../models/processor';

@Injectable({
  providedIn: 'root'
})
export class ProcessorService {

  private url: string = this.baseUrl + "processor";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<Processor[]> {
    return this.http.get<Processor[]>(this.url);
  }

  getById(id: number): Observable<Processor> {
    const url = `${this.url}/${id}`;
    return this.http.get<Processor>(url);
  }

  insert(processor: Processor): Observable<Processor> {
    return this.http.post<Processor>(this.url, processor, this.httpOptions);
  }

  update(processor: Processor): Observable<Processor> {
    return this.http.put<Processor>(this.url,processor, this.httpOptions)
  }

  delete(id: number): Observable<Processor> {
    const url = `${this.url}/${id}`;
    return this.http.delete<Processor>(url, this.httpOptions);
  }

}
