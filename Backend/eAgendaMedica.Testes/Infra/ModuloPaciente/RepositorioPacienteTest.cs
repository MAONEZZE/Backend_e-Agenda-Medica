using Microsoft.EntityFrameworkCore.Storage;
using eAgendaMedica.Infra.ModuloPaciente;

namespace eAgendaMedica.Testes.Infra.ModuloPaciente
{
    [TestClass]
    public class RepositorioPacienteTest : SetupBase, IDisposable
    {
        private RepositorioPaciente repPaciente;
        private eAgendaMedicaDbContext dbCtx;
        private IDbContextTransaction transaction;

        [TestInitialize]
        public void Setup()
        {
            dbCtx = new eAgendaMedicaDbContext(base.BuilderDbCtx.Options);

            repPaciente = new RepositorioPaciente(dbCtx);

            transaction = dbCtx.Database.BeginTransaction();

            BuilderSetup.SetCreatePersistenceMethod<Paciente>(async paciente => await repPaciente.InserirAsync(paciente));
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();

            dbCtx.Dispose();
        }

        [TestMethod]
        public async Task Deve_adicionar_um_paciente()
        {
            var paciente = Builder<Paciente>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var paciente1 = await repPaciente.SelecionarPorIdAsync(paciente.Id);

            paciente1.Should().Be(paciente);
        }

        [TestMethod]
        public async Task Deve_editar_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var paciente2 = await repPaciente.SelecionarPorIdAsync(paciente1.Id);
            paciente2.Nome = "Marcos";
            paciente2.Cpf = "123.123.123-33";
            paciente2.Telefone = "(11)96357-4015";
            paciente2.Email = "ruan@gmail.com";
            paciente2.DataNascimento = new DateTime(2020, 07, 02);

            repPaciente.Editar(paciente2);
            await dbCtx.SaveChangesAsync();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(paciente2);
        }

        [TestMethod]
        public async Task Deve_excluir_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var pacienteSelecionado = await repPaciente.SelecionarPorIdAsync(paciente1.Id);

            repPaciente.Excluir(pacienteSelecionado);
            await dbCtx.SaveChangesAsync();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var pacienteSelecionado = await repPaciente.SelecionarPorIdAsync(paciente1.Id);

            pacienteSelecionado.Should().Be(paciente1);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_pacientes()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();

            var paciente2 = Builder<Paciente>.CreateNew().Persist();

            var paciente3 = Builder<Paciente>.CreateNew().Persist();

            var paciente4 = Builder<Paciente>.CreateNew().Persist();
            await dbCtx.SaveChangesAsync();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
