using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Compartilhado;
using eAgendaMedica.Infra.ModuloCirurgia;
using eAgendaMedica.Infra.ModuloConsulta;
using eAgendaMedica.Infra.ModuloPaciente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace eAgendaMedica.Testes.Infra.ModuloAtividade
{
    [TestClass]
    public class RepositorioAtividadeTest : IDisposable
    {
        private RepositorioCirurgia repCirurgia;
        private RepositorioConsulta repConsulta;

        private eAgendaMedicaDbContext dbCtx;
        private IDbContextTransaction transaction;

        [TestInitialize]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eAgendaMedicaTeste;Integrated Security=True;");

            dbCtx = new eAgendaMedicaDbContext(builder.Options);

            repCirurgia = new RepositorioCirurgia(dbCtx);
            repConsulta = new RepositorioConsulta(dbCtx);

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
        public void Deve_adicionar_uma_Cirurgia()
        {
            var cirurgia = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            repCirurgia.SelecionarPorIdAsync(cirurgia.Id).Should().Be(cirurgia);
        }

        [TestMethod]
        public void Deve_adicionar_uma_Consulta()
        {
            var consulta = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            repConsulta.SelecionarPorIdAsync(consulta.Id).Should().Be(consulta);
        }

        [TestMethod]
        public async Task Deve_editar_um_Cirurgia()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var cirurgia2 = await repCirurgia.SelecionarPorIdAsync(consulta1.Id);

            cirurgia2.Titulo = "bariatrica";
            cirurgia2.HoraInicio = new TimeSpan(02, 00, 00);
            cirurgia2.HoraTermino = new TimeSpan(04, 00, 00);

            repCirurgia.Editar(cirurgia2);
            dbCtx.SaveChanges();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(cirurgia2);
        }

        [TestMethod]
        public async Task Deve_editar_um_Consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var consulta2 = await repCirurgia.SelecionarPorIdAsync(consulta1.Id);

            consulta2.Titulo = "consulta de rotina";
            consulta2.HoraInicio = new TimeSpan(02, 00, 00);
            consulta2.HoraTermino = new TimeSpan(04, 00, 00);

            repCirurgia.Editar(consulta2);
            dbCtx.SaveChanges();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(consulta2);
        }

        [TestMethod]
        public async Task Deve_excluir_uma_cirurgia()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var cirugiaSelecionado = await repCirurgia.SelecionarPorIdAsync(cirurgia1.Id);

            repCirurgia.Excluir(cirugiaSelecionado);
            dbCtx.SaveChanges();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_excluir_uma_consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var consultaSelecionado = await repConsulta.SelecionarPorIdAsync(consulta1.Id);

            repConsulta.Excluir(consultaSelecionado);
            dbCtx.SaveChanges();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_uma_cirurgia()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var cirurgiaSelecionado = await repCirurgia.SelecionarPorIdAsync(cirurgia1.Id);

            cirurgiaSelecionado.Should().Be(cirurgia1);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_uma_consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var consultaSelecionado = await repConsulta.SelecionarPorIdAsync(consulta1.Id);

            consultaSelecionado.Should().Be(consulta1);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_cirurgias()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia4 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_consultas()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta2 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta3 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta4 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_para_hoje()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);

            var lista = await repCirurgia.SelecionarCirurgiasParaHoje();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_para_hoje()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta2 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta3 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);

            var lista = await repConsulta.SelecionarConsultasParaHoje();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_passadas()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);

            var lista = await repCirurgia.SelecionarCirurgiasPassadas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_passadas()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta2 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta3 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);

            var lista = await repConsulta.SelecionarConsultasPassadas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_futuras()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().Persist();
            dbCtx.SaveChanges();

            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);

            var lista = await repCirurgia.SelecionarCirurgiasFuturas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_futuras()
        {
            var consulta1 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta2 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();
            var consulta3 = Builder<Consulta>.CreateNew().Persist();
            dbCtx.SaveChanges();

            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);

            var lista = await repConsulta.SelecionarConsultasFuturas();

            lista.Count.Should().Be(1);
        }


        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
