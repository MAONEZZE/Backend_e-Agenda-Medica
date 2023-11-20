import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarMedicoComponent } from './listar-medico/listar-medico.component';
import { InserirMedicoComponent } from './inserir-medico/inserir-medico.component';
import { EditarMedicoComponent } from './editar-medico/editar-medico.component';
import { ExcluirMedicoComponent } from './excluir-medico/excluir-medico.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listar',
    pathMatch: 'full'
  },
  {
    path: 'listar',
    component:ListarMedicoComponent
  },
  {
    path: 'inserir',
    component: InserirMedicoComponent
  },
  {
    path: 'editar',
    component: EditarMedicoComponent
  },
  {
    path: 'excluir',
    component: ExcluirMedicoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedicoRoutingModule { }
