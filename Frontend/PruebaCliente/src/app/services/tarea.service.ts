import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Tarea {
  id: number;
  title: string; 
  description: string;
  IsCompleted: boolean;
  Duedate: Date;
}

@Injectable({
  providedIn: 'root',
})
export class TareaService {
  
  private apiUrl = 'http://localhost:5051/api/tarea';

  constructor(private http: HttpClient) {}

  getTareas(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  createTarea(tarea: Tarea): Observable<any> {
    return this.http.post(this.apiUrl, tarea);
  }

  updateTarea(id: number, tarea: Tarea): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, tarea);
  }

  deleteTarea(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
