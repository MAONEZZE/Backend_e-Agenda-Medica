using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Compartilhado;
using eAgendaMedica.Infra.ModuloCirurgia;
using eAgendaMedica.Infra.ModuloConsulta;
using eAgendaMedica.Infra.ModuloMedico;
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
        private Medico medico;
        private Paciente paciente;

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

            var repPaciente = new RepositorioPaciente(dbCtx);
            var repMedico = new RepositorioMedico(dbCtx);

            transaction = dbCtx.Database.BeginTransaction();//permite que vc faça alterações no banco de dados

            BuilderSetup.SetCreatePersistenceMethod<Cirurgia>(async cirurgia => await repCirurgia.InserirAsync(cirurgia));
            BuilderSetup.SetCreatePersistenceMethod<Consulta>(async consulta => await repConsulta.InserirAsync(consulta));

            BuilderSetup.SetCreatePersistenceMethod<Paciente>(async paciente => await repPaciente.InserirAsync(paciente));
            BuilderSetup.SetCreatePersistenceMethod<Medico>(async medico => await repMedico.InserirAsync(medico));

            paciente = Builder<Paciente>.CreateNew().Persist();
            medico = Builder<Medico>.CreateNew().Persist();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();

            dbCtx.Dispose();
        }

        [TestMethod]
        public async Task Deve_adicionar_uma_Cirurgia()
        {
            var cirurgia = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();

            await dbCtx.SaveChangesAsync();

            var cirurgia1 = await repCirurgia.SelecionarPorIdAsync(cirurgia.Id);

            cirurgia1.Should().Be(cirurgia);
        }

        [TestMethod]
        public async Task Deve_adicionar_uma_Consulta()
        {
            var consulta = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var consulta1 = await repConsulta.SelecionarPorIdAsync(consulta.Id);

            consulta1.Should().Be(consulta);
        }

        [TestMethod]
        public async Task Deve_editar_um_Cirurgia()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var cirurgia2 = await repCirurgia.SelecionarPorIdAsync(cirurgia1.Id);

            cirurgia2.Titulo = "bariatrica";
            cirurgia2.HoraInicio = new TimeSpan(02, 00, 00);
            cirurgia2.HoraTermino = new TimeSpan(04, 00, 00);

            repCirurgia.Editar(cirurgia2);
            await dbCtx.SaveChangesAsync();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(cirurgia2);
        }

        [TestMethod]
        public async Task Deve_editar_um_Consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var consulta2 = await repConsulta.SelecionarPorIdAsync(consulta1.Id);

            consulta2.Titulo = "consulta de rotina";
            consulta2.HoraInicio = new TimeSpan(02, 00, 00);
            consulta2.HoraTermino = new TimeSpan(04, 00, 00);

            repConsulta.Editar(consulta2);
            await dbCtx.SaveChangesAsync();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(1);
            lista[0].Should().Be(consulta2);
        }

        [TestMethod]
        public async Task Deve_excluir_uma_cirurgia()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var cirugiaSelecionado = await repCirurgia.SelecionarPorIdAsync(cirurgia1.Id);

            repCirurgia.Excluir(cirugiaSelecionado);
            await dbCtx.SaveChangesAsync();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_excluir_uma_consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var consultaSelecionado = await repConsulta.SelecionarPorIdAsync(consulta1.Id);

            repConsulta.Excluir(consultaSelecionado);
            await dbCtx.SaveChangesAsync();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_uma_cirurgia()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var cirurgiaSelecionado = await repCirurgia.SelecionarPorIdAsync(cirurgia1.Id);

            cirurgiaSelecionado.Should().Be(cirurgia1);
        }

        [TestMethod]
        public async Task Deve_selecionar_por_ID_uma_consulta()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var consultaSelecionado = await repConsulta.SelecionarPorIdAsync(consulta1.Id);

            consultaSelecionado.Should().Be(consulta1);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_cirurgias()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia4 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var lista = await repCirurgia.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_os_consultas()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta2 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta3 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta4 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            await dbCtx.SaveChangesAsync();

            var lista = await repConsulta.SelecionarTodosAsync();

            lista.Count.Should().Be(4);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_para_hoje()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();

            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();

            var lista = await repCirurgia.SelecionarCirurgiasParaHoje();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_para_hoje()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta2 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta3 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();

            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();

            var lista = await repConsulta.SelecionarConsultasParaHoje();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_passadas()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();

            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();

            var lista = await repCirurgia.SelecionarCirurgiasPassadas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_passadas()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta2 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta3 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            
            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();


            var lista = await repConsulta.SelecionarConsultasPassadas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_cirurgias_futuras()
        {
            var cirurgia1 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            var cirurgia3 = Builder<Cirurgia>.CreateNew().With(x => x.Medicos = new List<Medico>() { this.medico }).With(x => x.PacienteAtributo = this.paciente).Persist();
            
            cirurgia1.Data = new DateTime(2023, 11, 26);
            cirurgia2.Data = new DateTime(2023, 11, 10);
            cirurgia3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();



            var lista = await repCirurgia.SelecionarCirurgiasFuturas();

            lista.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Deve_selecionar_consultas_futuras()
        {
            var consulta1 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta2 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();
            var consulta3 = Builder<Consulta>.CreateNew().With(x => x.Medico = this.medico).With(x => x.PacienteAtributo = this.paciente).Persist();

            consulta1.Data = new DateTime(2023, 11, 26);
            consulta2.Data = new DateTime(2023, 11, 10);
            consulta3.Data = new DateTime(2023, 12, 20);
            await dbCtx.SaveChangesAsync();

            var lista = await repConsulta.SelecionarConsultasFuturas();

            lista.Count.Should().Be(1);
        }

        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
