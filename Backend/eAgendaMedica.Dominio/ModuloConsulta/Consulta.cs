using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade<Consulta>
    {
        public Medico Medico { get; set; }

        public Guid Id_Medico
        {
            get
            {
                return Medico.Id;
            }
        }

        public Consulta() { }

        public Consulta(Guid id, string titulo, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo, Medico medico) 
        {
            Id = id;
            Titulo = titulo;
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
            Medico = medico;
        }

        public Consulta(string titulo, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo, Medico medico)
        {
            Titulo = titulo;
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
            Medico = medico;
        }

        public void AdicionarMedico(Medico medico)
        {
            this.Medico = medico;
        }

        public override bool Equals(object? obj)
        {
            return obj is Consulta consulta &&
                   Id.Equals(consulta.Id) &&
                   Titulo == consulta.Titulo &&
                   Paciente_id.Equals(consulta.Paciente_id) &&
                   Data == consulta.Data &&
                   HoraInicio.Equals(consulta.HoraInicio) &&
                   HoraTermino.Equals(consulta.HoraTermino);
        }
    }
}
