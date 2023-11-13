using eAgendaMedica.Dominio.ModuloConsulta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloConsulta
{
    public class MapeadorConsulta : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("TBConsulta");

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Titulo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.HoraTermino).HasColumnType("bigint").IsRequired();

            builder.HasOne(x => x.Medico)
                .WithMany(x => x.Consultas)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PacienteAtributo)
                .WithMany(x => x.Consultas).IsRequired().HasForeignKey(x => x.Paciente_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
