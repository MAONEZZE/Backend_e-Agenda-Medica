using eAgendaMedica.Dominio.ModuloAtividade;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloAtividade
{
    public class MapeadorAtividade : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("TBAtividade");
        }
    }
}
