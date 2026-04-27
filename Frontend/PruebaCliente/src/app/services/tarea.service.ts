import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TareaService {
  
  private apiUrl = 'http://localhost:5051/api/tarea';

  constructor(private http: HttpClient) {}

  getTareas(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
