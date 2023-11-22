import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedicoRoutingModule } from './medico-routing.module';
import { ExcluirMedicoComponent } from './excluir-medico/excluir-medico.component';
import { EditarMedicoComponent } from './editar-medico/editar-medico.component';
import { InserirMedicoComponent } from './inserir-medico/inserir-medico.component';
import { ListarMedicoComponent } from './listar-medico/listar-medico.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgModel, ReactiveFormsModule } from '@angular/forms';
import { CardComponent } from './card/card.component';


@NgModule({
  declarations: [
    ExcluirMedicoComponent,
    EditarMedicoComponent,
    InserirMedicoComponent,
    ListarMedicoComponent,
    CardComponent,
  ],
  imports: [
    CommonModule,
    MedicoRoutingModule,
    SharedModule,
    ReactiveFormsModule,
  ]
})
export class MedicoModule { }
