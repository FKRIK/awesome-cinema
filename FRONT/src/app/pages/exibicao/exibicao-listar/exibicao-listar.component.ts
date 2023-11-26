import { Component } from '@angular/core';
import { Exibicao } from '../../../models/exibicao.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-exibicao-listar',
  templateUrl: './exibicao-listar.component.html',
  styleUrl: './exibicao-listar.component.css'
})
export class ExibicaoListarComponent {
  exibicoesCadastradas!: Exibicao[];

  constructor(private client: HttpClient){ }

  ngOnInit(): void{
    this.client
      .get<Exibicao[]>("https://localhost:7206/api/exibicao/listar")
      .subscribe({
        next: (data) => {
          this.exibicoesCadastradas = data;
          console.log(data);
        },
        error: (erro) => {
          console.log(erro);
        }
      });
  }

  atualizaExibicoes(dados: Exibicao){
    this.exibicoesCadastradas.push(dados);
  }

  excluirExibicao(id: any): void{    
    this.client
    .delete<Exibicao>(`https://localhost:7206/api/exibicao/deletar/${id}`)
    .subscribe({
      next: (data) => {
        console.log(data);
        this.ngOnInit();
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  alterarExibicao(id: any): void{

  }
}
