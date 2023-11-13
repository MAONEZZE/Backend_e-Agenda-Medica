using FluentValidation;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome inválido. O nome deve conter no minimo 3 caracteres");

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("CPF inválido. O formato deve ser xxx.xxx.xxx-xx");

            RuleFor(x => x.Crm)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{5}-[A-Z]{2}$")
                .WithMessage("CRM inválido. O formato deve ser 12345-SP");


        }
    }
}
