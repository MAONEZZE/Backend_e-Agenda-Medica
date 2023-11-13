using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade
    {
        public Medico Medico { get; set; }

        public Consulta(Guid id, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo, Medico medico) 
        {
            this.Id = id;
            this.Data = data;
            this.HoraInicio = horainicio;
            this.HoraTermino = horatermino;
            this.PacienteAtributo = pacienteatributo;
            this.Medico = medico;
        }

        public Consulta(DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo, Medico medico)
        {
            this.Data = data;
            this.HoraInicio = horainicio;
            this.HoraTermino = horatermino;
            this.PacienteAtributo = pacienteatributo;
            this.Medico = medico;
        }
    }
}
