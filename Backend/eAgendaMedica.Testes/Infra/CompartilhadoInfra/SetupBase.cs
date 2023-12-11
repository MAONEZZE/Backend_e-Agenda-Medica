namespace eAgendaMedica.Testes.Infra.CompartilhadoInfra
{
    public class SetupBase
    {
        protected DbContextOptionsBuilder<eAgendaMedicaDbContext> BuilderDbCtx { get; set; }

        public SetupBase()
        {
            BuilderDbCtx = new DbContextOptionsBuilder<eAgendaMedicaDbContext>()
                .UseNpgsql(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eAgendaMedicaTeste;Integrated Security=True;");
        }
    }
}
