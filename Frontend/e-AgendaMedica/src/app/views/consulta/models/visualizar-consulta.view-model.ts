import { ListarMedicoVM } from "../../medico/models/listar-medico.view-model";
import { ListarPacienteVM } from "../../paciente/models/listar-paciente.view-model";

export type VisualizarConsultaVM = {
  id: string;
  Titulo: string;
  PacienteAtributo: ListarPacienteVM;
  Data: Date;
  HoraInicio: string;
  HoraTermino: string;
  Medicos: ListarMedicoVM;
  
}