namespace eAgendaMedica.Dominio.ModuloPaciente
{
    public class Paciente : EntidadeBase<Paciente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

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
    }
}
