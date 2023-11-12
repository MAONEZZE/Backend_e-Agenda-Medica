using eAgendaMedica.Dominio.ModuloPaciente;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloPaciente
{
    public class MapeadorPaciente : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("TBPaciente");
        }
    }
}
