import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListarPacienteComponent } from './views/paciente/listar-paciente/listar-paciente.component';
import { ExcluirPacienteComponent } from './views/paciente/excluir-paciente/excluir-paciente.component';
import { EditarPacienteComponent } from './views/paciente/editar-paciente/editar-paciente.component';
import { InserirPacienteComponent } from './views/paciente/inserir-paciente/inserir-paciente.component';
import { provideHttpClient } from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { DashboardModule } from './views/dashboard/dashboard.module';

@NgModule({
  declarations: [
    AppComponent,
    ListarPacienteComponent,
    ExcluirPacienteComponent,
    EditarPacienteComponent,
    InserirPacienteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CoreModule,
    DashboardModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
