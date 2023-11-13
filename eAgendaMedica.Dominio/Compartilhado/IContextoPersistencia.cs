namespace eAgendaMedica.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        public Task GravarDadosAsync();
    }
}
