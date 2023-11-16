using eAgendaMedica.Dominio.ModuloMedico;
using FluentValidation;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public class ValidadorConsulta : AbstractValidator<Consulta>
    {

        public ValidadorConsulta()
        {
            RuleFor(x => x.Data)
                .NotNull()
                .NotEmpty();
            
            RuleFor(x => x.HoraInicio)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.HoraTermino)
                .GreaterThan(x => x.HoraInicio)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PacienteAtributo)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Medico)
                .NotNull()
                .NotEmpty()
                .Custom(VerificadorDisponibilidade);
        }

        private void VerificadorDisponibilidade(Medico medico, ValidationContext<Consulta> ctx)
        {
            
        }
    }
}
