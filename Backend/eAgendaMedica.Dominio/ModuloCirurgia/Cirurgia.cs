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

        public override bool Equals(object? obj)
        {
            return obj is Cirurgia cirurgia &&
                   Id.Equals(cirurgia.Id) &&
                   Titulo == cirurgia.Titulo &&
                   Paciente_id.Equals(cirurgia.Paciente_id) &&
                   Data == cirurgia.Data &&
                   HoraInicio.Equals(cirurgia.HoraInicio) &&
                   HoraTermino.Equals(cirurgia.HoraTermino);
        }
    }
}
