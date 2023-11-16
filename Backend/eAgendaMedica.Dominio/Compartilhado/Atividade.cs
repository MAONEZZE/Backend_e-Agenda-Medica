using eAgendaMedica.Dominio.ModuloPaciente;
using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public abstract class Atividade<T> : EntidadeBase<T>
    {
        [NotMapped]
        public string Titulo { get; set; }
        public Guid Paciente_id 
        {
            get
            {
                return PacienteAtributo.Id;
            }

            set
            {
                Paciente_id = value;
            }
        }

        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Paciente PacienteAtributo { get; set; }
    }
}
