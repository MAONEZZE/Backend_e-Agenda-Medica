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

        public TimeSpan HorasTotaisTrabalhadas { get; private set; }
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

        public void HorasTrabalhadasPeriodoTempo(DateTime dataInicio, DateTime dataFinal)
        {
            long horasTrabalhadas = 0;
            

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

            HorasTotaisTrabalhadas = TimeSpan.FromHours(horasTrabalhadas);
        }

        public bool EstaDisponivelAtividade<T>(Atividade<T> atividadeNova)
        {
            //TODO - Acertar a lógica


            return true;

            //DateTime dataHoraFinal = DateTime.MinValue;
            //DateTime dataHoraInicio = DateTime.MaxValue;

            //bool disponivel = true;

            //foreach (var item in SelecionarAtividades())
            //{
            //    if(item is Consulta)
            //    {
            //        var consulta = (Consulta)item;

            //        var dataHoraFinalConsultaExistente = consulta.Data.Add(consulta.HoraTermino);
            //        var dataHoraInicioConsultaExistente = consulta.Data.Add(consulta.HoraInicio);

            //        if (dataHoraFinalConsultaExistente > dataHoraFinal && dataHoraFinalConsultaExistente < atividadeNova.Data.Add(atividadeNova.HoraInicio))
            //        {
            //            dataHoraFinal = dataHoraFinalConsultaExistente;
            //        }
                    
            //        if (dataHoraInicioConsultaExistente < dataHoraInicio && dataHoraInicioConsultaExistente > atividadeNova.Data.Add(atividadeNova.HoraTermino))
            //        {
            //            dataHoraInicio = dataHoraInicioConsultaExistente;
            //        }

            //        if (Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraInicio) - dataHoraFinal).Ticks) < TimeSpan.FromMinutes(20).Ticks)
            //        {
            //            disponivel = false;
            //        }
            //        else if (Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraTermino) - dataHoraInicio).Ticks) < TimeSpan.FromMinutes(20).Ticks)
            //        {
            //            disponivel = false;
            //        }

            //    }
            //    else
            //    {
            //        var cirurgia = (Cirurgia)item;

            //        var dataHoraFinalCirurgiaExistente = cirurgia.Data.Add(cirurgia.HoraTermino);
            //        var dataHoraInicioCirurgiaExistente = cirurgia.Data.Add(cirurgia.HoraInicio);

            //        if (dataHoraFinalCirurgiaExistente > dataHoraFinal && dataHoraFinalCirurgiaExistente < atividadeNova.Data.Add(atividadeNova.HoraInicio))
            //        {
            //            dataHoraFinal = dataHoraFinalCirurgiaExistente;
            //        }
                   
            //        if (dataHoraInicioCirurgiaExistente < dataHoraInicio && dataHoraInicioCirurgiaExistente > atividadeNova.Data.Add(atividadeNova.HoraTermino))
            //        {
            //            dataHoraInicio = dataHoraInicioCirurgiaExistente;
            //        }

            //        if (Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraInicio) - dataHoraFinal).Ticks) < TimeSpan.FromHours(4).Ticks)
            //        {
            //            disponivel = false;
            //        }
            //        else if(Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraTermino) - dataHoraInicio).Ticks) < TimeSpan.FromHours(4).Ticks)
            //        {
            //            disponivel = false;
            //        }
            //    }
            //}

            //return disponivel;
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
