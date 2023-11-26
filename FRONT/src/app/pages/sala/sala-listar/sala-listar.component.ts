import { Component } from '@angular/core';
import { Sala } from '../../../models/sala.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sala-listar',
  templateUrl: './sala-listar.component.html',
  styleUrl: './sala-listar.component.css'
})
export class SalaListarComponent {
  salasCadastradas!: Sala[];
  byDisponivel!: boolean;
  byAssentos!: number;

  constructor(private client: HttpClient){ }

  ngOnInit(): void {
    //console.log("sala componente carregado");

    this.client
      .get<Sala[]>("https://localhost:7206/api/sala/listar")
      .subscribe({
        next: (salas) => {
          this.salasCadastradas = salas;
          console.table(salas);
        },
        error: (erro) => {
          console.log(erro);
        }
      });
  }

  atualizaSalas(dados: Sala){
    this.salasCadastradas.push(dados);
  }

  filtraSalas(): void{
    if(this.byDisponivel != null){
      this.client
      .get<Sala[]>(`https://localhost:7206/api/sala/listar/${this.byDisponivel}`)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.salasCadastradas = [];
          this.salasCadastradas = data;
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
    if(this.byAssentos != null){
      this.client
      .get<Sala[]>(`https://localhost:7206/api/sala/listar/${this.byAssentos}`)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.salasCadastradas = [];
          this.salasCadastradas = data;
        },
        error: (error) => {
          console.log(error);
        }
      })
    }

    if(this.byAssentos == null && this.byDisponivel == null){
      this.ngOnInit();
    }
  }

  alterarSala(id: any): void{

  }

  excluirSala(id: any): void{
    this.client
    .delete<Sala>(`https://localhost:7206/api/sala/deletar/${id}`)
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
}
