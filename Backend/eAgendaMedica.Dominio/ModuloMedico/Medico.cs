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

        public TimeSpan HorasTotaisTrabalhadasPriodoTempo { get; private set; }
        public TimeSpan HorasTotaisTrabalhadas
        {
            get
            {
                return HorasTrabalhadas();
            }
        }

        public List<string> TitulosConsultas 
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

        private TimeSpan HorasTrabalhadas()
        {
            double horasTrabalhadas = 0;

            foreach (var item in Consultas)
            {
                horasTrabalhadas += item.HoraTermino.Ticks - item.HoraInicio.Ticks;   
            }

            foreach (var item in Cirurgias)
            {
                horasTrabalhadas += item.HoraTermino.Ticks - item.HoraInicio.Ticks;
            }

            return TimeSpan.FromHours(horasTrabalhadas);
        }

        public void HorasTrabalhadasPeriodoTempo(DateTime dataInicio, DateTime dataFinal)
        {
            double horasTrabalhadas = 0;

            foreach (var item in Consultas)
            {
                if(item.Data <= dataFinal && item.Data >= dataInicio)
                {
                    horasTrabalhadas += item.HoraTermino.Ticks - item.HoraInicio.Ticks;
                }
            }

            foreach (var item in Cirurgias)
            {
                if (item.Data <= dataFinal && item.Data >= dataInicio)
                {
                    horasTrabalhadas += item.HoraTermino.Ticks - item.HoraInicio.Ticks;
                }
            }

            HorasTotaisTrabalhadasPriodoTempo = TimeSpan.FromHours(horasTrabalhadas);
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
