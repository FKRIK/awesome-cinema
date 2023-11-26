import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmeCadastrarComponent } from './pages/filme/filme-cadastrar/filme-cadastrar.component';
import { FilmeListarComponent } from './pages/filme/filme-listar/filme-listar.component';
import { SalaCadastrarComponent } from './pages/sala/sala-cadastrar/sala-cadastrar.component';
import { SalaListarComponent } from './pages/sala/sala-listar/sala-listar.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { IngressoListarComponent } from './pages/ingresso/ingresso-listar/ingresso-listar.component';
import { IngressoCadastrarComponent } from './pages/ingresso/ingresso-cadastrar/ingresso-cadastrar.component';
import { ExibicaoListarComponent } from './pages/exibicao/exibicao-listar/exibicao-listar.component';
import { ExibicaoCadastrarComponent } from './pages/exibicao/exibicao-cadastrar/exibicao-cadastrar.component';

@NgModule({
  declarations: [
    AppComponent,
    FilmeCadastrarComponent,
    FilmeListarComponent,
    SalaCadastrarComponent,
    SalaListarComponent,
    IngressoListarComponent,
    IngressoCadastrarComponent,
    ExibicaoListarComponent,
    ExibicaoCadastrarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
