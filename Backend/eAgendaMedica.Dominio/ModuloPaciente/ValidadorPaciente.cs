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
                .Matches(@"^(\(\d{2}\)\s?\d{5}-\d{4}|\d{10})$")
                .WithMessage("Telefone inválido. O formato deve ser (99)99999-9999");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull();
        }
    }
}
