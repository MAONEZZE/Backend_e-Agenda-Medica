namespace eAgendaMedica.Testes.Dominio.ModuloPaciente
{
    [TestClass]
    public  class PacienteTest
    {
        private ValidadorPaciente validador;
        private Paciente paciente;

        [TestInitialize]
        public void Setup()
        {
            validador = new ValidadorPaciente();
            paciente = new Paciente("pedro", "a@b.com", "(11)12345-1234", "123.456.678-56", new DateTime(2020, 07, 02));
        }

        [TestMethod]
        public void Deve_validar_paciente()
        {
            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_meno_que_3_caracteres_no_nome()
        {
            paciente.Nome = "ab";

            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_email1_fora_do_formato()
        {
            paciente.Email = "a@";

            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeFalse();
        }

        public void Nao_deve_aceitar_email2_fora_do_formato()
        {
            paciente.Email = "a@b";

            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_cpf_fora_do_formato()
        {
            paciente.Cpf = "131234.234-34";

            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_telefone_fora_do_formato()
        {
            paciente.Telefone = "(11)2123-4334";

            ValidationResult resultado = validador.Validate(paciente);

            resultado.IsValid.Should().BeFalse();
        }        
    }
}
