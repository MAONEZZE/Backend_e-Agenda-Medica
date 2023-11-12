using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public class Atividade : EntidadeBase<Atividade>
    {
        public TipoAtividadeEnum TipoAtividade { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Paciente PacienteAtributo { get; set; }
        public List<Medico> Medicos { get; set; }

        public Atividade()
        {
            this.Medicos = new List<Medico>();
        }

        public Atividade(Guid id, TipoAtividadeEnum tipoatividade, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            base.Id = id;
            this.TipoAtividade = tipoatividade;
            this.Data = data;
            this.HoraInicio = horainicio;
            this.HoraTermino = horatermino;
            this.PacienteAtributo = pacienteatributo;
        }

        public Atividade(TipoAtividadeEnum tipoatividade, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            this.TipoAtividade = tipoatividade;
            this.Data = data;
            this.HoraInicio = horainicio;
            this.HoraTermino = horatermino;
            this.PacienteAtributo = pacienteatributo;
        }
    }
}
