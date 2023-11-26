import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Sala } from '../../../models/sala.model';

@Component({
  selector: 'app-sala-cadastrar',
  templateUrl: './sala-cadastrar.component.html',
  styleUrl: './sala-cadastrar.component.css'
})
export class SalaCadastrarComponent {
  assentos: number = 0;

  constructor(private client: HttpClient) {}
  @Output()elementoCadastrado= new EventEmitter<Sala>();

  onSubmit(): void{
    let sala: Sala = {
      assentos: this.assentos
    };

    this.client
      .post<Sala>("https://localhost:7206/api/sala/cadastrar", sala)
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
      console.table(sala);
  }
}
