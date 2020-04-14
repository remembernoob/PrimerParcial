import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteRegistroComponent } from './cliente/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent } from './cliente/cliente-consulta/cliente-consulta.component';

import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'clienteRegistro',
    component: ClienteRegistroComponent
  },
  {
    path: 'clienteConsulta',
    component: ClienteConsultaComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
