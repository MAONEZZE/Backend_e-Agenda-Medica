using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : EntidadeBase<Medico>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }

        public List<string> TituloConsulta 
        {
            get
            {
                var lista = new List<string>();

                foreach(var item in Consultas)
                {
                    lista.Add(item.Titulo);
                }

                return lista;
            }
        }

        public List<string> TituloCirurgia
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

        public List<object> SelecionarAtividades()
        {
            var lista = new List<object>();

            lista.AddRange(Consultas);
            lista.AddRange(Cirurgias);

            return lista;
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            this.Consultas.Add(consulta);
        }

        public void AdicionarCirurgia(Cirurgia cirurgia)
        {
            this.Cirurgias.Add(cirurgia);
        }

        public bool EstaDisponivelCirurgia(DateTime dataHoraMarcada)
        {
            //TODO - Fazer uma verificação, caso tenha uma cirurgia depois da dataHoraMarcada
            //TODO - Fazer um metodo geral, para pegar a disponibilidade do medico a independente de uma Consulta ou Cirurgia
            //TODO - Troacr o Cirurgias do foreach pelo metodo SelecionarAtividades()

            DateTime dataHoraFinal = new DateTime();

            foreach (var c in Cirurgias)
            {
                var dataHoraUltimaCirurgia = c.Data.Add(c.HoraTermino);


                if (dataHoraUltimaCirurgia > dataHoraFinal)
                {
                    dataHoraFinal = dataHoraUltimaCirurgia;
                }
            }

            if (Math.Abs((dataHoraMarcada - dataHoraFinal).Ticks) < TimeSpan.FromHours(4).Ticks)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Medico medico &&
                   Id.Equals(medico.Id) &&
                   Nome == medico.Nome &&
                   Cpf == medico.Cpf &&
                   Crm == medico.Crm;
        }
    }
}
