using eAgendaMedica.Infra.Compartilhado;
using eAgendaMedica.Infra.ModuloMedico;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using eAgendaMedica.Infra.ModuloPaciente;

namespace eAgendaMedica.Testes.Infra.ModuloPaciente
{
    [TestClass]
    public class RepositorioPacienteTest : IDisposable
    {
        private RepositorioPaciente repPaciente;
        private eAgendaMedicaDbContext dbCtx;
        private IDbContextTransaction transaction;

        [TestInitialize]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eAgendaMedicaTeste;Integrated Security=True;");

            dbCtx = new eAgendaMedicaDbContext(builder.Options);

            repPaciente = new RepositorioPaciente(dbCtx);

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
        public void Deve_adicionar_um_paciente()
        {
            var paciente = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();

            repPaciente.SelecionarPorIdAsync(paciente.Id).Should().Be(paciente);
        }

        [TestMethod]
        public async Task Deve_editar_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var paciente2 = await repPaciente.SelecionarPorIdAsync(paciente1.Id);
            paciente2.Nome = "Marcos";
            paciente2.Cpf = "123.123.123-33";
            paciente2.Telefone = "(11)96357-4015";
            paciente2.Email = "ruan@gmail.com";
            paciente2.DataNascimento = new DateTime(2020, 07, 02);

            repPaciente.Editar(paciente2);
            dbCtx.SaveChanges();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(paciente2);
        }

        [TestMethod]
        public async Task Deve_excluir_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var pacienteSelecionado = await repPaciente.SelecionarPorIdAsync(paciente1.Id);

            repPaciente.Excluir(pacienteSelecionado);
            dbCtx.SaveChanges();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_um_paciente()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var pacienteSelecionado = await repPaciente.SelecionarPorIdAsync(paciente1.Id);

            pacienteSelecionado.Should().Be(paciente1);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_pacientes()
        {
            var paciente1 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var paciente2 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var paciente3 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var paciente4 = Builder<Paciente>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var lista = await repPaciente.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
