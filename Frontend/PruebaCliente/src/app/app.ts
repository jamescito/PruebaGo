import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TareaComponent } from './components/tarea/tarea.component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TareaComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('PruebaCliente');
}
