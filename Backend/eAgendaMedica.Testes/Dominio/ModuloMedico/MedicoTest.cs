namespace eAgendaMedica.Testes.Dominio.ModuloMedico
{
    [TestClass]
    public class MedicoTest
    {
        private ValidadorMedico validador;
        private Medico medico;

        [TestInitialize]
        public void Setup()
        {
            validador = new ValidadorMedico();
            medico = new Medico("Antonio", "324.234.246-56", "12345-SP");
        }

        [TestMethod]
        public void Deve_validar_medico()
        {
            ValidationResult resultado = validador.Validate(medico);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_crm_fora_do_formato()
        {
            medico.Crm = "123-2D";

            ValidationResult resultado = validador.Validate(medico);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_cpf_fora_do_formato()
        {
            medico.Cpf = "131234.234-34";

            ValidationResult resultado = validador.Validate(medico);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_meno_que_3_caracteres_no_nome()
        {
            medico.Nome = "ab";

            ValidationResult resultado = validador.Validate(medico);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
