using eAgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloMedico
{
    public class MapeadorMedico : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("TBMedico");

            builder.Property(m => m.Id).ValueGeneratedNever();

            builder.Ignore(m => m.HorasTotaisTrabalhadasPriodoTempo);

            builder.Property(m => m.Nome).HasColumnType("varchar(50)").IsRequired();

            builder.HasIndex(m => m.Crm).IsUnique();
            builder.HasIndex(m => m.Cpf).IsUnique();

            builder.Property(m => m.Cpf).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.Crm).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
