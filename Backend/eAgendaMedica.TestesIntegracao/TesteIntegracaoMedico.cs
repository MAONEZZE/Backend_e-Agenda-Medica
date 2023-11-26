using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Compartilhado;
using eAgendaMedica.Infra.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace eAgendaMedica.TestesIntegracao
{
    [TestClass]
    public class TesteIntegracaoMedico : IDisposable
    {
        private eAgendaMedicaDbContext db;
        private RepositorioMedico repMedico;
        private IDbContextTransaction transaction;

        private Medico InicializarMedico()
        {
            return new Medico("Antonio", "123.123.123-33", "12345-SP");
        }

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eAgendaMedicaTest;Integrated Security=True");

            db = new eAgendaMedicaDbContext(builder.Options);

            repMedico = new RepositorioMedico(db);

            transaction = db.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();

            db.Dispose();
        }

        [TestMethod]
        public void Deve_inserir_medico()
        {
            //Arrange
            var medico = InicializarMedico();

            //Action
            repMedico.InserirAsync(medico);

            //Assert
            
        }


















        public void Dispose()
        {
            db.Dispose();
        }
    }
}