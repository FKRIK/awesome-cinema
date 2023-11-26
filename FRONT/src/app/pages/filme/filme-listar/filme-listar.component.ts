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
  byYear: string = "";
  byNota!: number;
  byCartaz!: boolean;
  filmeEdit!: Filme;

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
    //console.log(this.byYear);
    if(this.byYear != '')
    {
      this.client
      .get<Filme[]>(`https://localhost:7206/api/filme/listar/anolancamento/${this.byYear}`)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.filmesCadastrados = [];
          this.filmesCadastrados = data;
        },
        error: (error) => {
          console.log(error);
        }
      })
    }

    if(this.byNota != null)
    {
      this.client
      .get<Filme[]>(`https://localhost:7206/api/filme/listar/avaliacao/${this.byNota}`)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.filmesCadastrados = [];
          this.filmesCadastrados = data;
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
    
    if(this.byCartaz != null)
    {
      this.client
      .get<Filme[]>(`https://localhost:7206/api/filme/listar/emcartaz/${this.byCartaz}`)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.filmesCadastrados = [];
          this.filmesCadastrados = data;
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
  }

  excluirFilme(id: any): void
  {
    this.client
    .delete<Filme>(`https://localhost:7206/api/filme/deletar/${id}`)
    .subscribe({
      next: (data) => {
        console.log("deletou");
        console.log(data);
        this.ngOnInit();
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  alterarFilme(id: any): void
  {
    // console.log(id);

    this.client
      .get<Filme>(`https://localhost:7206/api/filme/listar/${id}`)
      .subscribe({
        next: (data) => {
          this.filmeEdit = data;
          console.log(this.filmeEdit);
        },
        error: (error) => {
          console.log(error);
        }
      })
  }
}
