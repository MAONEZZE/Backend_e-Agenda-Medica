using eAgendaMedica.Dominio.ModuloMedico;
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
                .NotEmpty()
                .Custom(VerificadorDisponibilidade);



        }

        private void VerificadorDisponibilidade(List<Medico> medicos, ValidationContext<Cirurgia> ctx)
        {
            //TODO - fazer acessar o metodo de verificação de disponibilidade do medico
            //foreach (var medico in medicos)
            //{
            //    bool disponivel = medico.EstaDisponivelCirurgia();

            //    if (!disponivel)
            //    {
            //        ctx.AddFailure(new ValidationFailure("Tempo de Descanço", $"É necessario que o medico {medico.Nome} fique no mínimo 4 horas descansando, após uma cirurgia"));
            //    }
            //}
        }
    }
}
