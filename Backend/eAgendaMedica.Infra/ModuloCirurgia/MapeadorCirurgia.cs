using eAgendaMedica.Dominio.ModuloCirurgia;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.ModuloCirurgia
{
    public class MapeadorCirurgia : IEntityTypeConfiguration<Cirurgia>
    {
        public void Configure(EntityTypeBuilder<Cirurgia> builder)
        {
            builder.ToTable("TBCirurgia");

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Titulo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.HoraTermino).HasColumnType("bigint").IsRequired();

            builder.HasMany(x => x.Medicos)//Muitas cirurgias tem muitos medicos
                .WithMany(x => x.Cirurgias)//Muitos medicos tem muitas cirurgias, isso faz com que
                                           //a lista Cirurgias sejam preenchidas com as cirurgias relacionadas ao medico
                .UsingEntity(x => x.ToTable("TBMedico_Cirurgia"));

            builder.HasOne(x => x.PacienteAtributo)
                .WithMany(x => x.Cirurgias).IsRequired()
                .HasForeignKey(x => x.Paciente_id).OnDelete(DeleteBehavior.Cascade);

            //TODO - para remover o false do isrequired é preciso excluir os registros do banco de dados
            //TODO - tem fazer um update-database ainda.  
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
