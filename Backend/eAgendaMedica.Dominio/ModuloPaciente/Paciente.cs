
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloPaciente
{
    public class Paciente : EntidadeBase<Paciente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public List<string> TitulosConsultas
        {
            get
            {
                var lista = new List<string>();

                foreach (var item in Consultas)
                {
                    lista.Add(item.Titulo);
                }

                return lista;
            }
        }

        public List<string> TitulosCirurgias
        {
            get
            {
                var lista = new List<string>();

                foreach (var item in Cirurgias)
                {
                    lista.Add(item.Titulo);
                }

                return lista;
            }
        }

        public int QtdConsultas 
        {
            get
            {
                return Consultas.Count();
            }
        }
        public int QtdCirurgias 
        {
            get
            {
                return Cirurgias.Count();
            }
        }

        public List<Consulta> Consultas { get; set; }
        public List<Cirurgia> Cirurgias { get; set; }

        public Paciente()
        {
            this.Consultas = new List<Consulta>();
            this.Cirurgias = new List<Cirurgia>();
        }

        public Paciente(Guid id, string nome, string email, string telefone, string cpf, DateTime data)
        {
            base.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cpf = cpf;
            this.DataNascimento = data;
        }

        public Paciente(string nome, string email, string telefone, string cpf, DateTime data)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cpf = cpf;
            this.DataNascimento = data;
        }

        public override bool Equals(object? obj)
        {
            return obj is Paciente paciente &&
                   Id.Equals(paciente.Id) &&
                   Nome == paciente.Nome &&
                   Email == paciente.Email &&
                   Telefone == paciente.Telefone &&
                   Cpf == paciente.Cpf &&
                   DataNascimento == paciente.DataNascimento;
        }
    }
}
