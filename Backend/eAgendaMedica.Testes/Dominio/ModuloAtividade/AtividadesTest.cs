namespace eAgendaMedica.Testes.Dominio.ModuloAtividade
{
    [TestClass]
    public class AtividadesTest
    {
        private readonly Medico medico = new Medico("Antonio", "324.234.246-56", "12345-SP");
        private readonly Paciente paciente = new Paciente("assdasd", "a@b.com", "(11) 12345-1234", "123.456.678-56", new DateTime());

        private readonly TimeSpan duasHoras = TimeSpan.FromHours(2);
        private readonly TimeSpan quatroHoras = TimeSpan.FromHours(4);
        private readonly TimeSpan seisHoras = TimeSpan.FromHours(6);
        private readonly TimeSpan oitoHoras = TimeSpan.FromHours(8);
        private readonly TimeSpan dezHoras = TimeSpan.FromHours(10);

        private ValidadorCirurgia validadorCirurgia;
        private ValidadorConsulta validadorConsulta;

        private Consulta consultaInicio_2_Termino_6;
        private Cirurgia cirurgiaInicio_2_Termino_6;

        [TestInitialize]
        public void Setup()
        {
            validadorCirurgia = new ValidadorCirurgia();
            validadorConsulta = new ValidadorConsulta();

            consultaInicio_2_Termino_6 = new Consulta(new DateTime(2020, 07, 02), duasHoras, seisHoras, paciente, medico);
            cirurgiaInicio_2_Termino_6 = new Cirurgia(new DateTime(2020, 07, 02), duasHoras, seisHoras, paciente);
        }

        [TestMethod]
        public void Deve_validar_Consulta()
        {
            ValidationResult resultado = validadorConsulta.Validate(consultaInicio_2_Termino_6);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_validar_Cirurgia()
        {
            ValidationResult resultado = validadorCirurgia.Validate(cirurgiaInicio_2_Termino_6);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_5_caracteres_no_titulo_da_Cirurgia()
        {
            cirurgiaInicio_2_Termino_6.Titulo = "abcd";

            ValidationResult resultado = validadorCirurgia.Validate(cirurgiaInicio_2_Termino_6);

            resultado.IsValid.Should().BeFalse();
        }

        public void Nao_deve_aceitar_menos_que_5_caracteres_no_titulo_da_Consulta()
        {
            consultaInicio_2_Termino_6.Titulo = "abcd";

            ValidationResult resultado = validadorConsulta.Validate(consultaInicio_2_Termino_6);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_retornar_true_se_anterior_for_cirurgia_intervalo_maiorOUigual_4horas()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(11, 14, 18), paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(true);
        }

        [TestMethod]
        public void Deve_retornar_false_se_tentar_inserir_novaCirurgia_mesmo_horarioInicio_cirurgiaExistente()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), duasHoras, oitoHoras, paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Deve_retornar_false_se_anterior_for_cirurgia_intervalo_menor_4horas()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), oitoHoras, new TimeSpan(11, 14, 18), paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Deve_retornar_false_caso_dataMarcada_seja_igualOUmaior_que_DataInicio_de_Cirurgia_existente()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), seisHoras, oitoHoras, paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }


        [TestMethod]
        public void Deve_inserir_novaCirurgia_entre_duas_cirurgiasExistente()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            var cirurgia2 = new Cirurgia(new DateTime(2020, 07, 02), new TimeSpan(17, 14, 18), new TimeSpan(18, 14, 18), paciente);
            medico.AdicionarCirurgia(cirurgia2);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(11, 14, 18), paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(true);
        }

        [TestMethod]
        public void Nao_Deve_inserir_novaCirurgia_entre_duas_cirurgiasExistente_comHoraFinal_maiorOUigual_CirurgiaExistenteHoraInicio()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            var cirurgia2 = new Cirurgia(new DateTime(2020, 07, 02), new TimeSpan(17, 14, 18), new TimeSpan(18, 14, 18), paciente);
            medico.AdicionarCirurgia(cirurgia2);

            //Action
            var cirurgiaMarcada = new Cirurgia(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(17, 14, 18), paciente);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Cirurgia>(cirurgiaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        //=======================================

        [TestMethod]
        public void Deve_retornar_true_se_anterior_for_consulta_intervalo_maiorOUigual_20min()
        {
            //Arrange
            medico.AdicionarConsulta(consultaInicio_2_Termino_6);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(11, 14, 18), paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(true);
        }

        [TestMethod]
        public void Deve_retornar_false_se_anterior_for_consulta_intervalo_menor_20min()
        {
            //Arrange
            medico.AdicionarConsulta(consultaInicio_2_Termino_6);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), new TimeSpan(6, 14, 18), new TimeSpan(11, 14, 18), paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }


        [TestMethod]
        public void Deve_inserir_novaConsulta_entre_duas_cirurgiasExistente()
        {
            //Arrange
            medico.AdicionarConsulta(consultaInicio_2_Termino_6);

            var consulta2 = new Consulta(new DateTime(2020, 07, 02), new TimeSpan(17, 14, 18), new TimeSpan(18, 14, 18), paciente, medico);
            medico.AdicionarConsulta(consulta2);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(11, 14, 18), paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(true);
        }

        [TestMethod]
        public void Nao_Deve_inserir_novaConsulta_entre_duas_consultasExistente_comHoraFinal_maiorOUigual_ConsultaExistenteHoraInicio()
        {
            //Arrange
            medico.AdicionarConsulta(consultaInicio_2_Termino_6);

            var consulta2 = new Consulta(new DateTime(2020, 07, 02), new TimeSpan(17, 00, 00), new TimeSpan(18, 00, 00), paciente, medico);
            medico.AdicionarConsulta(consulta2);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), dezHoras, new TimeSpan(17, 00, 00), paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Nao_Deve_inserir_consultas_com_horarios_iguais()
        {
            //Arrange
            medico.AdicionarConsulta(consultaInicio_2_Termino_6);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), duasHoras, seisHoras, paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Nao_Deve_inserir_novaConsulta_apos_uma_cirurgia_com_intervalo_menor4h()
        {
            //Arrange
            medico.AdicionarCirurgia(cirurgiaInicio_2_Termino_6);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), oitoHoras, dezHoras, paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_uma_consulta_com_horarioFinal_igual_CirurgiaHorarioInicio()
        {
            //Arrange
            var cirurgia1 = new Cirurgia(new DateTime(2020, 07, 02), seisHoras, oitoHoras, paciente);
            medico.AdicionarCirurgia(cirurgia1);

            //Action
            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaInicio_2_Termino_6);

            //Assert
            disponivel.Should().Be(false);
        }

        [TestMethod]
        public void Nao_Deve_Inserir_uma_consulta_no_meio_de_duas_cirurgias_com_horarioFinal_igual_CirurgiaHorarioInicio()
        {
            //Arrange
            var cirurgia1 = new Cirurgia(new DateTime(2020, 07, 02), seisHoras, quatroHoras, paciente);
            medico.AdicionarCirurgia(cirurgia1);

            var cirurgia2 = new Cirurgia(new DateTime(2020, 07, 02), TimeSpan.FromHours(12), TimeSpan.FromHours(13), paciente);
            medico.AdicionarCirurgia(cirurgia2);

            //Action
            var consultaMarcada = new Consulta(new DateTime(2020, 07, 02), oitoHoras, TimeSpan.FromHours(12), paciente, medico);

            var disponivel = medico.VerificadorDisponibilidadeMedico<Consulta>(consultaMarcada);

            //Assert
            disponivel.Should().Be(false);
        }


    }
}
