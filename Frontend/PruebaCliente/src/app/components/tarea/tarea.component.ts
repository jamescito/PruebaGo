import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { TareaService, Tarea } from '../../services/tarea.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tarea',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './tarea.html',
  styleUrls: ['./tarea.css']
})
export class TareaComponent implements OnInit {
  tareas: any[] = []; 
  filtro: string = '';
  editando = false;
  tareaEditando: any = null;
  
  nuevaTarea: any = {
    id: 0,
    Title: '',
    Description: '',
    IsCompleted: false,
    Duedate: new Date().toISOString().split('T')[0]
  };

  constructor(private _tareaService: TareaService, private cd: ChangeDetectorRef) {}

  ngOnInit(): void { this.obtenerTareas(); }

  obtenerTareas() {
    this._tareaService.getTareas().subscribe({
      next: (data: any[]) => {
        // Mapeo para que no importe si viene en minúscula o mayúscula
        this.tareas = data.map(t => ({
          id: t.id ?? t.Id,
          Title: t.title ?? t.Title,
          Description: t.description ?? t.Description,
          IsCompleted: t.isCompleted ?? t.IsCompleted ?? false,
          Duedate: t.duedate ?? t.Duedate
        }));
        this.cd.detectChanges();
      },
      error: (e) => console.error(e)
    });
  }

  agregarOActualizar() {
    // Aseguramos que el objeto tenga las mayúsculas que espera el backend
    const payload = {
      Id: this.nuevaTarea.id,
      Title: this.nuevaTarea.Title,
      Description: this.nuevaTarea.Description,
      IsCompleted: this.nuevaTarea.IsCompleted,
      Duedate: new Date(this.nuevaTarea.Duedate)
    };

    if (this.editando) {
      this._tareaService.updateTarea(this.nuevaTarea.id, payload as any).subscribe(() => {
        this.obtenerTareas();
        this.cancelar();
      });
    } else {
      this._tareaService.createTarea(payload as any).subscribe(() => {
        this.obtenerTareas();
        this.limpiar();
      });
    }
  }

  editar(t: any) {
    this.editando = true;
    this.tareaEditando = t;
    this.nuevaTarea = { ...t };
    if (this.nuevaTarea.Duedate) {
      this.nuevaTarea.Duedate = new Date(this.nuevaTarea.Duedate).toISOString().split('T')[0];
    }
    this.cd.detectChanges();
  }

  eliminar(id: number) {
    if(confirm('¿Borrar?')) {
      this._tareaService.deleteTarea(id).subscribe(() => this.obtenerTareas());
    }
  }

  cancelar() {
    this.editando = false;
    this.limpiar();
  }

  limpiar() {
    this.nuevaTarea = { id: 0, Title: '', Description: '', IsCompleted: false, Duedate: new Date().toISOString().split('T')[0] };
    this.cd.detectChanges();
  }

  get tareasFiltradas() {
    return this.tareas.filter(t => t.Title?.toLowerCase().includes(this.filtro.toLowerCase()));
  }
}