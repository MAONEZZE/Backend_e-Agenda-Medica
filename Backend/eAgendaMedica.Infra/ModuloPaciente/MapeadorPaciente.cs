using eAgendaMedica.Dominio.ModuloPaciente;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloPaciente
{
    public class MapeadorPaciente : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("TBPaciente");

            builder.Property(m => m.Id).ValueGeneratedNever();

            builder.HasIndex(m => m.Cpf).IsUnique();

            builder.Property(m => m.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.Cpf).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.Telefone).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.DataNascimento).IsRequired();
        }
    }
}
