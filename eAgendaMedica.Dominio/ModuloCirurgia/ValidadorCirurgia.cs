using FluentValidation;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class ValidadorCirurgia : AbstractValidator<Cirurgia>
    {
        public ValidadorCirurgia()
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

            RuleFor(x => x.Medicos)
                .NotNull()
                .NotEmpty();
        }
    }
}
