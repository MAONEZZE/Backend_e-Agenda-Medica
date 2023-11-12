using Microsoft.EntityFrameworkCore.Design;

namespace eAgendaMedica.Infra.Compartilhado
{
    public class eAgendaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            builder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial 
                                Catalog=eAgendaMedica;
                                Integrated Security=True;
                                Connect Timeout=30;
                                Encrypt=False;
                                Trust Server Certificate=False;
                                Application Intent=ReadWrite;
                                Multi Subnet Failover=False");

            return new eAgendaMedicaDbContext(builder.Options);
        }
    }
}
