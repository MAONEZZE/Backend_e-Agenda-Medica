using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Dominio.ModuloPaciente;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace eAgendaMedica.Infra.Compartilhado
{
    public class eAgendaMedicaDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>, IContextoPersistencia
    {
        private Guid usuario_id;
        public eAgendaMedicaDbContext(DbContextOptions options, ITenantProvider tenantProvider = null) : base(options)
        {
            if(tenantProvider != null)
            {
                this.usuario_id = tenantProvider.Usuario_id;
            }
        }

        public async Task GravarDadosAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create((x) => 
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = typeof(eAgendaMedicaDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            #region Para que serve o HasQueryFilter()?
            /* 
             * Esse metodo serve como um filtro global, o qual está filtrando pelo id do usuario,
             * ou seja, só irá acessar os dados relacionados ao respectivo usuario, assim 
             * não precisa dos filtros em cada consulta que fizer por meio dos repositorios.
             * 
             * ex: Where(x => x.UsuarioId == usuarioId) --> não precisa
             */
            #endregion

            modelBuilder.Entity<Medico>().HasQueryFilter(x => x.UsuarioId == usuario_id);
            modelBuilder.Entity<Paciente>().HasQueryFilter(x => x.UsuarioId == usuario_id);
            modelBuilder.Entity<Cirurgia>().HasQueryFilter(x => x.UsuarioId == usuario_id);
            modelBuilder.Entity<Consulta>().HasQueryFilter(x => x.UsuarioId == usuario_id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
