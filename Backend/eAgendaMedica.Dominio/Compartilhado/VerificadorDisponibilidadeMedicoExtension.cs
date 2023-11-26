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
            bool disponivel = false;

            if(medico.Consultas.Count == 0 && medico.Cirurgias.Count == 0)
            {
                return true;
            }

            foreach (var item in medico.SelecionarAtividades())
            {
                TimeSpan tempoRecuperacao;
                

                Guid idAtividadeExistente = Guid.Empty;

                var atvNovaDataHoraTermino = atividadeNova.Data.Add(atividadeNova.HoraTermino);
                var atvNovaDataHoraInicio = atividadeNova.Data.Add(atividadeNova.HoraInicio);

                DateTime dataHoraInicioExistente = DefinirHoraInicioExistente(item, ref idAtividadeExistente);
                DateTime dataHoraFinalExistente = DefinirHoraFinalExistente(item);

                bool horariosIguais = dataHoraFinalExistente == atvNovaDataHoraTermino || dataHoraInicioExistente == atvNovaDataHoraInicio;
                bool horarioCruzado = dataHoraFinalExistente == dataHoraInicioExistente || dataHoraInicioExistente == atvNovaDataHoraTermino;

                if (idAtividadeExistente == atividadeNova.Id)
                {
                    continue;
                }
                else if (horariosIguais)
                {
                    disponivel = false;
                }
                else if (horarioCruzado)
                {
                    disponivel = false;
                }
                else
                {
                    if(atividadeNova is Cirurgia)
                    {
                        disponivel = AtividadeNovaCirurgia(item, atvNovaDataHoraTermino, atvNovaDataHoraInicio, dataHoraInicioExistente, dataHoraFinalExistente);
                    }
                    else
                    {
                        disponivel = AtividadeNovaConsulta(item, atvNovaDataHoraTermino, atvNovaDataHoraInicio, dataHoraInicioExistente, dataHoraFinalExistente);
                    }
                }
            }

            return disponivel;
        }

        private static bool AtividadeNovaConsulta(object item, DateTime atvNovaDataHoraTermino, DateTime atvNovaDataHoraInicio, DateTime dataHoraInicioExistente, DateTime dataHoraFinalExistente)
        {
            if (atvNovaDataHoraTermino < dataHoraInicioExistente && (dataHoraInicioExistente - atvNovaDataHoraTermino).TotalMinutes >= TimeSpan.FromMinutes(20).TotalMinutes)
            {
                return true;
            }
            else if (atvNovaDataHoraInicio > dataHoraFinalExistente && item is Cirurgia && (atvNovaDataHoraInicio - dataHoraFinalExistente).TotalMinutes >= TimeSpan.FromHours(4).TotalMinutes)
            {
                return true;
            }
            else if (atvNovaDataHoraInicio > dataHoraFinalExistente && item is Consulta && (atvNovaDataHoraInicio - dataHoraFinalExistente).TotalMinutes >= TimeSpan.FromMinutes(20).TotalMinutes)
            {
                return true;
            }

            return false;

        }

        private static bool AtividadeNovaCirurgia(object item, DateTime atvNovaDataHoraTermino, DateTime atvNovaDataHoraInicio, DateTime dataHoraInicioExistente, DateTime dataHoraFinalExistente)
        {
            if (atvNovaDataHoraTermino < dataHoraInicioExistente && (dataHoraInicioExistente - atvNovaDataHoraTermino).TotalMinutes >= TimeSpan.FromHours(4).TotalMinutes)
            {
                return true;
            }
            else if (atvNovaDataHoraInicio > dataHoraFinalExistente && item is Cirurgia && (atvNovaDataHoraInicio - dataHoraFinalExistente).TotalMinutes >= TimeSpan.FromHours(4).TotalMinutes)
            {
                return true;
            }
            else if (atvNovaDataHoraInicio > dataHoraFinalExistente && item is Consulta && (atvNovaDataHoraInicio - dataHoraFinalExistente).TotalMinutes >= TimeSpan.FromMinutes(20).TotalMinutes)
            {
                return true;
            }

            return false;
        }

        private static DateTime DefinirHoraFinalExistente(object item)
        {
            DateTime dataHoraFinalExistente;

            if (item is Consulta)
            {
                Consulta consulta = (Consulta)item;
                dataHoraFinalExistente = consulta.Data.Add(consulta.HoraTermino);
            }
            else
            {
                Cirurgia cirurgia = (Cirurgia)item;
                dataHoraFinalExistente = cirurgia.Data.Add(cirurgia.HoraTermino);
            }

            return dataHoraFinalExistente;
        }

        private static DateTime DefinirHoraInicioExistente(object item, ref Guid idAtividadeExistente)
        {
            DateTime dataHoraInicioExistente;

            if (item is Consulta)
            {
                Consulta consulta = (Consulta)item;

                idAtividadeExistente = consulta.Id;

                dataHoraInicioExistente = consulta.Data.Add(consulta.HoraInicio);
            }
            else
            {
                Cirurgia cirurgia = (Cirurgia)item;

                idAtividadeExistente = cirurgia.Id;

                dataHoraInicioExistente = cirurgia.Data.Add(cirurgia.HoraInicio);
            }

            return dataHoraInicioExistente;
        }
    }
}







//if (dataHoraFinalExistente >= dataHoraFinal)
////verifica o maior horario final de uma atividade existente mais proximo do inicio dessa nova atividade
//{
//    dataHoraFinal = dataHoraFinalExistente;
//}

//if (dataHoraInicioExistente <= dataHoraInicio)
////verifica o menor horario inicial de uma atividade existente mais proximo do final dessa nova atividade
//{
//    dataHoraInicio = dataHoraInicioExistente;
//}

////verifica se tem tempo de recuperação suficiente

//if (Math.Abs((atividadeNovaDataHoraInicio - dataHoraFinal).Ticks) < tempoRecuperacao.Ticks)
//{
//    disponivel = false;
//    break;
//}
//else if (Math.Abs((atividadeNovaDataHoraTermino - dataHoraInicio).Ticks) < tempoRecuperacao.Ticks)
//{
//    disponivel = false;
//    break;
//}