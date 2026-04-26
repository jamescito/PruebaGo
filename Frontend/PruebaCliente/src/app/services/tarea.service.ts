import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TareaService {
  
  private apiUrl = 'http://localhost:8080/api/tareas';

  constructor(private http: HttpClient) {}

  getTareas(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
