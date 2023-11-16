using eAgendaMedica.Dominio.Compartilhado;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace eAgendaMedica.Infra.Compartilhado
{
    public class eAgendaMedicaDbContext : DbContext, IContextoPersistencia
    {
        public eAgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
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

            base.OnModelCreating(modelBuilder);
        }

    }
}
