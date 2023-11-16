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

        public async void Process(FormCirurgiaViewModel cirurgiaVM, Cirurgia cirurgia, ResolutionContext ctx)
        {
            var listaMed = await repMedico.SelecionarMuitosAsync(cirurgiaVM.Id_Medicos);

            cirurgia.Medicos.AddRange(listaMed);
        }
    }
}