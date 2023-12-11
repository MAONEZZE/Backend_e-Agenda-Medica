using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace eAgendaMedica.Infra.Compartilhado
{
    public class eAgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("PostgreSql");

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var dbcontext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            var migrador = new MigradorDb();

            migrador.AtualizarDb(dbcontext);

            return dbcontext;
        }
    }
}
