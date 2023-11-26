import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmeListarComponent } from './pages/filme/filme-listar/filme-listar.component';
import { FilmeCadastrarComponent } from './pages/filme/filme-cadastrar/filme-cadastrar.component';
import { SalaListarComponent } from './pages/sala/sala-listar/sala-listar.component';
import { SalaCadastrarComponent } from './pages/sala/sala-cadastrar/sala-cadastrar.component';
import { ExibicaoListarComponent } from './pages/exibicao/exibicao-listar/exibicao-listar.component';
import { ExibicaoCadastrarComponent } from './pages/exibicao/exibicao-cadastrar/exibicao-cadastrar.component';

const routes: Routes = [
  {
    path: "",
    component: FilmeListarComponent
  },
  {
    path: "pages/filmes/listar",
    component: FilmeListarComponent
  },
  {
    path: "pages/filmes/cadastar",
    component: FilmeCadastrarComponent
  },
  {
    path: "pages/salas/listar",
    component: SalaListarComponent
  },
  {
    path: "pages/salas/cadastrar",
    component: SalaCadastrarComponent
  },
  {
    path: "pages/exibicoes/listar",
    component: ExibicaoListarComponent
  },
  {
    path: "pages/exibicoes/cadastrar",
    component: ExibicaoCadastrarComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
