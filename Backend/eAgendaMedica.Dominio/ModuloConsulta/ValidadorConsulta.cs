using eAgendaMedica.Dominio.ModuloMedico;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

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
            var objConsulta = ctx.InstanceToValidate; // aqui eu tenho o objeto consulta

            bool disponivel = medico.VerificadorDisponibilidadeMedico(objConsulta);

            if (!disponivel)
            {
                ctx.AddFailure(new ValidationFailure("Tempo de Descanço", $"É necessario que o medico {medico.Nome} fique no mínimo 20 minutos descansando, após uma consulta"));
            }
        }
    }
}
