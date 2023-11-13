namespace eAgendaMedica.Dominio.Compartilhado
{
    public interface IRepositorioAtividade<T>
        where T : Atividade
    {
        public Task InserirAsync(T registro);
        public void Editar(T registro);
        public void Excluir(T registro);
        public Task<List<T>> SelecionarTodosAsync();
        public Task<T> SelecionarPorIdAsync(Guid id);
    }
}
