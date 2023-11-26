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
}
