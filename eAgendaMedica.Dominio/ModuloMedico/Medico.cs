using eAgendaMedica.Dominio.ModuloAtividade;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : EntidadeBase<Medico>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public List<Atividade> Atividades { get; set; }
        
        //Pensar na logica das horas de descanço

        public Medico()
        {
            this.Atividades = new List<Atividade>();
        }

        public Medico(string nome, string especialidade, string cpf, string crm) : this()
        {
            this.Nome = nome;
            this.Especialidade = especialidade;
            this.Cpf = cpf;
            this.Crm = crm;
        }

        public Medico(Guid id ,string nome, string especialidade, string cpf, string crm) : this()
        {
            base.Id = id;
            this.Nome = nome;
            this.Especialidade = especialidade;
            this.Cpf = cpf;
            this.Crm = crm;
        }
    }
}
