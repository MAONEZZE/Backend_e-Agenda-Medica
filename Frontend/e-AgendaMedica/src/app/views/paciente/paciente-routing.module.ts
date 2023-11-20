import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarPacienteComponent } from './listar-paciente/listar-paciente.component';
import { InserirPacienteComponent } from './inserir-paciente/inserir-paciente.component';
import { EditarPacienteComponent } from './editar-paciente/editar-paciente.component';
import { ExcluirPacienteComponent } from './excluir-paciente/excluir-paciente.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listar',
    pathMatch: 'full'
  },
  {
    path: 'listar',
    component: ListarPacienteComponent
  },
  {
    path: 'inserir',
    component: InserirPacienteComponent
  },
  {
    path: 'editar',
    component: EditarPacienteComponent
  },
  {
    path: 'excluir',
    component: ExcluirPacienteComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PacienteRoutingModule { }
