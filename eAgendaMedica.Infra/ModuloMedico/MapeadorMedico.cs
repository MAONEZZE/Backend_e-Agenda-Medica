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
            builder.Property(m => m.Cpf).HasColumnType("varchar(50)").IsRequired();
            builder.Property(m => m.Crm).HasColumnType("varchar(50)").IsRequired();

            builder.HasOne(m => m.Atividades)
        }
    }
}
