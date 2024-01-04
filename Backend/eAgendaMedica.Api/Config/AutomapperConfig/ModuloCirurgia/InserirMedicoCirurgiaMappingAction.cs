using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Api.Config.AutomapperConfig.ModuloCirurgia
{
    public class InserirMedicoCirurgiaMappingAction : IMappingAction<FormCirurgiaViewModel, Cirurgia>
    {
        private readonly IRepositorioMedico repMedico;
        public InserirMedicoCirurgiaMappingAction(IRepositorioMedico repMedico)
        {
            this.repMedico = repMedico;
        }

        public void Process(FormCirurgiaViewModel cirurgiaVM, Cirurgia cirurgia, ResolutionContext ctx)
        {
            cirurgia.Medicos.Clear();

            var listaMed = repMedico.SelecionarMuitosAsync(cirurgiaVM.Id_Medicos).Result;

            cirurgia.Medicos.AddRange(listaMed);
        }
    }
}