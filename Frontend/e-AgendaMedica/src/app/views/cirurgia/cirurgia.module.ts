import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CirurgiaRoutingModule } from './cirurgia-routing.module';
import { InserirCirurgiaComponent } from './inserir-cirurgia/inserir-cirurgia.component';
import { EditarCirurgiaComponent } from './editar-cirurgia/editar-cirurgia.component';
import { ExcluirCirurgiaComponent } from './excluir-cirurgia/excluir-cirurgia.component';
import { ListarCirurgiaComponent } from './listar-cirurgia/listar-cirurgia.component';
import { CirurgiaService } from './services/cirurgia.service';


@NgModule({
  declarations: [
    InserirCirurgiaComponent,
    EditarCirurgiaComponent,
    ExcluirCirurgiaComponent,
    ListarCirurgiaComponent
  ],
  imports: [
    CommonModule,
    CirurgiaRoutingModule
  ],
  providers: [CirurgiaService]
})
export class CirurgiaModule { }
