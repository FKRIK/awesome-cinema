import { Component } from '@angular/core';
import { Filme } from "../../../models/filme.model";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-filme-listar',
  templateUrl: './filme-listar.component.html',
  styleUrl: './filme-listar.component.css'
})
export class FilmeListarComponent {
  filmesCadastrados!: Filme[];
  byYear: number = 0;

  constructor(private client: HttpClient) {}

  ngOnInit(): void {
    this.client
      .get<Filme[]>("https://localhost:7206/api/filme/listar")
      .subscribe({
        next: (filmes) => {
          this.filmesCadastrados = filmes;
          console.table(filmes);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizaFilmes(dados: Filme){
    this.filmesCadastrados.push(dados);
  }

  filtraFilmes(): void{
    // console.log("filtra");
    this.client
      .get<Filme[]>(`https://localhost:7206/api/filme/listar/anolancamento/${this.byYear}`)
      .subscribe({
        next: (data) => {
          console.log(data);
        },
        error: (error) => {
          console.log(error);
        }
      })
  }
}
