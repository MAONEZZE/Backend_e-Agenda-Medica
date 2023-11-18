using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public static class VerificadorDisponibilidadeMedicoExtension
    {
        public static bool VerificadorDisponibilidadeMedico<T>(this Medico medico, Atividade<T> atividadeNova)
        {
            DateTime dataHoraFinal = DateTime.MinValue;
            DateTime dataHoraInicio = DateTime.MaxValue;

            bool disponivel = true;

            foreach (var item in medico.SelecionarAtividades())
            {
                TimeSpan tempoRecuperacao;
                DateTime dataHoraFinalExistente;
                DateTime dataHoraInicioExistente;

                if (item is Consulta)
                {
                    Consulta consulta = (Consulta)item;

                    tempoRecuperacao = TimeSpan.FromMinutes(20);

                    dataHoraFinalExistente = consulta.Data.Add(consulta.HoraTermino);
                    dataHoraInicioExistente = consulta.Data.Add(consulta.HoraInicio);
                }
                else
                {
                    Cirurgia cirurgia = (Cirurgia)item;

                    tempoRecuperacao = TimeSpan.FromHours(4);

                    dataHoraFinalExistente = cirurgia.Data.Add(cirurgia.HoraTermino);
                    dataHoraInicioExistente = cirurgia.Data.Add(cirurgia.HoraInicio);
                }

                if (dataHoraFinalExistente > dataHoraFinal && dataHoraFinalExistente <= atividadeNova.Data.Add(atividadeNova.HoraInicio))
                //verifica o maior horario final mais proximo do inicio dessa nova atividade
                {
                    dataHoraFinal = dataHoraFinalExistente;
                }

                if (dataHoraInicioExistente < dataHoraInicio && dataHoraInicioExistente >= atividadeNova.Data.Add(atividadeNova.HoraTermino))
                //verifica o menor horario inicial mais proximo do final dessa nova atividade
                {
                    dataHoraInicio = dataHoraInicioExistente;
                }

                //verifica se tem tempo de recuperação suficiente
                if (Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraInicio) - dataHoraFinal).Ticks) < tempoRecuperacao.Ticks)
                {
                    disponivel = false;
                }
                else if (Math.Abs((atividadeNova.Data.Add(atividadeNova.HoraTermino) - dataHoraInicio).Ticks) < tempoRecuperacao.Ticks)
                {
                    disponivel = false;
                }
            }

            return disponivel;
        }
    }
}
