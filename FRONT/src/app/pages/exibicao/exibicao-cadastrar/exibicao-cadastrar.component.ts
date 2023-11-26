import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { Exibicao } from '../../../models/exibicao.model';

@Component({
  selector: 'app-exibicao-cadastrar',
  templateUrl: './exibicao-cadastrar.component.html',
  styleUrl: './exibicao-cadastrar.component.css'
})
export class ExibicaoCadastrarComponent {
  dataHora: string = "";
  salaId!: number;
  filmeId!: number;

  constructor(private client: HttpClient) {}
  @Output()elementoCadastrado= new EventEmitter<Exibicao>();

  cadastrar(): void{ 
    console.log(this.dataHora);

    let exibicao: Exibicao = {
      dataHora: this.dataHora,
      salaId: this.salaId,
      filmeId: this.filmeId
    };

    this.client
      .post<Exibicao>("https://localhost:7206/api/exibicao/cadastrar", exibicao)
      .subscribe({
        next: (data) => {
          console.table(data);
          this.elementoCadastrado.emit(data);
          //TO-DO: add field cleaner
        },
        error: (erro) => {
          console.log(erro);
        }
      })
      console.table(exibicao);
  }
}
