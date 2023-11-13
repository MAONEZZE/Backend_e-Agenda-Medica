using FluentValidation;
using FluentValidation.Validators;

namespace eAgendaMedica.Dominio.ModuloPaciente
{
    public class ValidadorPaciente : AbstractValidator<Paciente>
    {
        public ValidadorPaciente()
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

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email inválido. O formato deve ser exemplo@extensao.com");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotEmpty()
                .Matches(@"^(\+\d{1,3}\s?)?(\()?(\d{2,3})?(\)?)?[-.\s]?(\d{4,5})[-.\s]?(\d{4})$")
                .WithMessage("Telefone inválido. O formato deve ser (99) 9999-9999");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull();
        }
    }
}
