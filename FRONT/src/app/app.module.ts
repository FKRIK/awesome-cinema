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

@NgModule({
  declarations: [
    AppComponent,
    FilmeCadastrarComponent,
    FilmeListarComponent,
    SalaCadastrarComponent,
    SalaListarComponent
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
