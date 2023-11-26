import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { Filme } from '../../../models/filme.model';

@Component({
  selector: 'app-filme-cadastrar',
  templateUrl: './filme-cadastrar.component.html',
  styleUrl: './filme-cadastrar.component.css'
})
export class FilmeCadastrarComponent {
  titulo: string = "";
  minutos: number = 0;
  ano: string = "";
  nota: number = 0;
  
  constructor(private client: HttpClient) {}
  @Output()elementoCadastrado= new EventEmitter<Filme>();

  onSubmit(): void {
    let filme: Filme = {
      titulo: this.titulo,
      duracao: this.minutos,
      anoLancamento: this.ano,
      avaliacao: this.nota
    };

    this.client
      .post<Filme>("https://localhost:7206/api/filme/cadastrar", filme)
      .subscribe({
        next: (data) => {
          console.log("Filme enviado");
          console.table(data);
          this.elementoCadastrado.emit(data);
          //TO-DO: add field cleaner
        },
        error: (erro) => {
          console.log(erro);
        }
    });
  }
}
