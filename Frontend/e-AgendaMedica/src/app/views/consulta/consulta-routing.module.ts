import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarConsultaComponent } from './listar-consulta/listar-consulta.component';
import { InserirConsultaComponent } from './inserir-consulta/inserir-consulta.component';
import { EditarConsultaComponent } from './editar-consulta/editar-consulta.component';
import { ExcluirConsultaComponent } from './excluir-consulta/excluir-consulta.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listar',
    pathMatch: 'full'
  },
  {
    path: 'listar',
    component: ListarConsultaComponent
  },
  {
    path: 'inserir',
    component: InserirConsultaComponent
  },
  {
    path: 'editar',
    component: EditarConsultaComponent
  },
  {
    path: 'excluir',
    component: ExcluirConsultaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultaRoutingModule { }
