using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Atividade<Cirurgia>
    {
        public List<Medico> Medicos { get; set; }

        public Cirurgia()
        {
            this.Medicos = new List<Medico>();
        }

        public Cirurgia(Guid id, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            Id = id;
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
        }

        public Cirurgia(DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
        }

        public void AdicioanrMedico(Medico medico)
        {
            this.Medicos.Add(medico);
        }
    }
}
