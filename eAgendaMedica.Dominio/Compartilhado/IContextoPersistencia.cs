namespace eAgendaMedica.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        public void DesfazerAlteracoes();

        public Task GravarDadosAsync();
    }
}
