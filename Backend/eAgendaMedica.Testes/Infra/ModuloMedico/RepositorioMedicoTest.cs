using eAgendaMedica.Infra.Compartilhado;
using eAgendaMedica.Infra.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace eAgendaMedica.Testes.Infra.ModuloMedico
{
    [TestClass]
    public class RepositorioMedicoTest : IDisposable
    {
        private RepositorioMedico repMedico;
        private eAgendaMedicaDbContext dbCtx;
        private IDbContextTransaction transaction;

        [TestInitialize]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eAgendaMedicaTeste;Integrated Security=True;");

            dbCtx = new eAgendaMedicaDbContext(builder.Options);

            repMedico = new RepositorioMedico(dbCtx);

            transaction = dbCtx.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();

            dbCtx.Dispose();
        }

        [TestMethod]
        public void Deve_adicionar_um_medico()
        {
            var medico = Builder<Medico>.CreateNew().Persist();
            dbCtx.SaveChanges();

            repMedico.SelecionarPorIdAsync(medico.Id).Should().Be(medico);
        }

        [TestMethod]
        public async Task Deve_editar_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var medico2 = await repMedico.SelecionarPorIdAsync(medico1.Id);
            medico2.Nome = "Marcos";
            medico2.Cpf = "123.123.123-33";
            medico2.Crm = "12344-SC";

            repMedico.Editar(medico2);
            dbCtx.SaveChanges();

            var lista = await repMedico.SelecionarTodosAsync();
            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_excluir_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var medicoSelecionado = await repMedico.SelecionarPorIdAsync(medico1.Id);

            repMedico.Excluir(medicoSelecionado);
            dbCtx.SaveChanges();

            var lista = await repMedico.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var medicoSelecionado = await repMedico.SelecionarPorIdAsync(medico1.Id);

            medicoSelecionado.Should().Be(medico1);
        }


        public void Dispose()
        {
            dbCtx.Dispose();
        }

    }
}
