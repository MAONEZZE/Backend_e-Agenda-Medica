using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Atividade<Cirurgia>
    {
        public List<Medico> Medicos { get; set; }
        public List<Guid> Id_Medicos
        {
            get
            {
                var lista = new List<Guid>();

                foreach(var item in Medicos)
                {
                    lista.Add(item.Id);
                }

                return lista;
            }
        }

        public Cirurgia()
        {
            this.Medicos = new List<Medico>();
        }

        public Cirurgia(Guid id, string titulo, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            Id = id;
            Titulo = titulo;
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
        }

        public Cirurgia(string titulo, DateTime data, TimeSpan horainicio, TimeSpan horatermino, Paciente pacienteatributo) : this()
        {
            Titulo = titulo;
            Data = data;
            HoraInicio = horainicio;
            HoraTermino = horatermino;
            PacienteAtributo = pacienteatributo;
        }

        public void AdicionarMedicos(Medico medico)
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
