using eAgendaMedica.Dominio.ModuloPaciente;
using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public abstract class Atividade<T> : EntidadeBase<T>
    {
        [NotMapped]
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Guid Paciente_id { get; set; }

        private Paciente paciente;
        public Paciente PacienteAtributo
        {
            get
            {
                return paciente;
            }
            set
            {
                paciente = value;
                Paciente_id = value.Id;
            }
        }
    }
}
