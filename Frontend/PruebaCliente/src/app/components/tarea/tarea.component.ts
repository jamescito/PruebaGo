import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { TareaService } from '../../services/tarea.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tarea',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tarea.html',
  styleUrl: './tarea.css'
})
export class TareaComponent implements OnInit {
  tareas: any[] = [];

  constructor(
    private _tareaService: TareaService,
    private cd: ChangeDetectorRef // 1. Inyecta esto
  ) {}

  ngOnInit(): void {
    this.obtenerTareas();
  }

  obtenerTareas() {
    this._tareaService.getTareas().subscribe({
      next: (data) => {
        this.tareas = data;
        this.cd.detectChanges(); // 2. Fuerza a Angular a pintar los datos
        console.log("Datos listos para el HTML:", this.tareas);
      },
      error: (e) => console.error("Error en API:", e)
    });
  }
}