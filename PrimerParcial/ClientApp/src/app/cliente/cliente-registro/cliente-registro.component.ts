import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {

  cliente:Cliente;
  constructor(private clienteService:ClienteService) { }

  ngOnInit(): void {
    this.cliente=new Cliente();
  }

  add(){
    this.clienteService.post(this.cliente).subscribe(p=>{
      if( p != null ){
        alert('Cliente Registrado con exito !!!!');
        this.cliente=p;
      }
    },
    (error) => {console.log(error)},
    () => {
      console.log("Error en al petición"+this.cliente);
    })
  }

}
