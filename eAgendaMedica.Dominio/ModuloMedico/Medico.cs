using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : EntidadeBase<Medico>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public List<Consulta> Consultas { get; set; }
        public List<Cirurgia> Cirurgias { get; set; }
        
        //Pensar na logica das horas de descanço

        public Medico()
        {
            this.Consultas = new List<Consulta>();
            this.Cirurgias = new List<Cirurgia>();
        }

        public Medico(string nome, string cpf, string crm) : this()
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Crm = crm;
        }

        public Medico(Guid id ,string nome, string cpf, string crm) : this()
        {
            base.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Crm = crm;
        }

        public void VerificadorDisponibilidade()
        {

        }
    }
}
