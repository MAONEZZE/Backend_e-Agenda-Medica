using eAgendaMedica.Api.ViewModels.ModuloCirurgia;
using eAgendaMedica.Api.ViewModels.ModuloMedico;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloMedico;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
            var listaMed = repMedico.SelecionarMuitosAsync(cirurgiaVM.Id_Medicos).Result;

            cirurgia.Medicos.AddRange(listaMed);
        }
    }
}