import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PacienteRoutingModule } from './paciente-routing.module';
import { CardComponent } from './card/card.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EditarPacienteComponent } from './editar-paciente/editar-paciente.component';
import { ExcluirPacienteComponent } from './excluir-paciente/excluir-paciente.component';
import { InserirPacienteComponent } from './inserir-paciente/inserir-paciente.component';
import { ListarPacienteComponent } from './listar-paciente/listar-paciente.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PacienteService } from './services/paciente.service';


@NgModule({
  declarations: [
    InserirPacienteComponent,
    EditarPacienteComponent,
    ExcluirPacienteComponent,
    ListarPacienteComponent,
    CardComponent
  ],
  imports: [
    CommonModule,
    PacienteRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers: [PacienteService]
})
export class PacienteModule { }
