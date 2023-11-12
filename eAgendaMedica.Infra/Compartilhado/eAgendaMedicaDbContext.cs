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

        public void DesfazerAlteracoes()
        {
            var registrosAlterados = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToList();

            foreach (var registro in registrosAlterados)
            {
                switch (registro.State)
                {
                    case EntityState.Added:
                        registro.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        registro.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        registro.State = EntityState.Unchanged;
                        registro.CurrentValues.SetValues(registro.OriginalValues);
                        break;

                    default:
                        break;
                }
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

            base.OnModelCreating(modelBuilder);
        }

    }
}
