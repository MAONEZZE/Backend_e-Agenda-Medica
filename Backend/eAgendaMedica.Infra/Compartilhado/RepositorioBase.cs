using eAgendaMedica.Dominio.Compartilhado;

namespace eAgendaMedica.Infra.Compartilhado
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity>
        where TEntity : EntidadeBase<TEntity>
    {
        protected DbSet<TEntity> dbset;
        private readonly DbContext dbContext;

        public RepositorioBase(IContextoPersistencia ctx)
            //O eAgendaMedicaDbContext implementa essa interface IContextoPersistencia.
            //Isso é feito para que caso queira implementar outro DbContext 
        {
            this.dbContext = (eAgendaMedicaDbContext)ctx;

            this.dbset = dbContext.Set<TEntity>();
        }

        public void Editar(TEntity registro)
        {
            this.dbset.Update(registro);
        }

        public void Excluir(TEntity registro)
        {
            this.dbset.Remove(registro);
        }

        public async Task InserirAsync(TEntity registro)
        {
            await this.dbset.AddAsync(registro);
        }

        public async Task<TEntity> SelecionarPorIdAsync(Guid id)
        {
            return await this.dbset.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> SelecionarTodosAsync()
        {
            return await dbset.ToListAsync();
        }
    }
}
