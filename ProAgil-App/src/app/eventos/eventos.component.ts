import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _textoFiltrado: string;
  get textoFiltrado(): string {
    return this._textoFiltrado;
  }
  set textoFiltrado(value: string){
    this._textoFiltrado = value;
    this.eventosFiltrados = this.textoFiltrado ? this.filtrarEventos(this.textoFiltrado) : this.eventos;
  }

  eventosFiltrados: any = [];
  eventos: any = [];
  imagemLargura = 30;
  imagemMargem = 2;
  mostrarImagem = false;
  alternarTextoBtn = "Mostrar Img";

  constructor(private http: HttpClient) {
  }

  filtrarEventos(filtrarPor : string) : any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  ngOnInit() {
    this.getEventos();
  }

  alternarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
    if(this.mostrarImagem){
      this.alternarTextoBtn = "Ocultar Img";
    }else{
      this.alternarTextoBtn = "Mostrar Img";
    }
  }

  getEventos(){
    this.http.get('http://localhost:5000/api/values').subscribe(response =>
    {
      this.eventos = response;
      console.log(response);
    }, error =>{
      console.log(error);
    });
  }
}
