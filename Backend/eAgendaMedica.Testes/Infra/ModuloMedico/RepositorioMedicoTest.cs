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

            BuilderSetup.SetCreatePersistenceMethod<Medico>(async medico => await repMedico.InserirAsync(medico));
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();

            dbCtx.Dispose();
        }

        [TestMethod]
        public async Task Deve_adicionar_um_medico()
        {
            var medico = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var medico1 = await repMedico.SelecionarPorIdAsync(medico.Id);

            medico1.Should().Be(medico);
        }

        [TestMethod]
        public async Task Deve_editar_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var medico2 = await repMedico.SelecionarPorIdAsync(medico1.Id);
            medico2.Nome = "Marcos";
            medico2.Cpf = "123.123.123-33";
            medico2.Crm = "12344-SC";

            repMedico.Editar(medico2);
            await dbCtx.SaveChangesAsync();

            var lista = await repMedico.SelecionarTodosAsync(new Guid());
            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_excluir_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var medicoSelecionado = await repMedico.SelecionarPorIdAsync(medico1.Id);

            repMedico.Excluir(medicoSelecionado);
            await dbCtx.SaveChangesAsync();

            var lista = await repMedico.SelecionarTodosAsync(new Guid());

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_um_medico()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var medicoSelecionado = await repMedico.SelecionarPorIdAsync(medico1.Id);

            medicoSelecionado.Should().Be(medico1);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_medicos()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico2 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico3 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico4 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();


            var lista = await repMedico.SelecionarTodosAsync(new Guid());

            lista.Count.Should().Be(4);

        }

        [TestMethod]
        public async Task Deve_selecionar_os_medicos_a_partir_de_lista_de_Guid()
        {
            var medico1 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico2 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico3 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();
            var medico4 = Builder<Medico>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            List<Guid> listaIds = new List<Guid>();

            listaIds.Add(medico1.Id);
            listaIds.Add(medico2.Id);
            listaIds.Add(medico3.Id);
            listaIds.Add(medico4.Id);

            var lista = await repMedico.SelecionarMuitosAsync(listaIds);

            lista.Count.Should().Be(4);
        }

        public void Dispose()
        {
            dbCtx.Dispose();
        }

    }
}
