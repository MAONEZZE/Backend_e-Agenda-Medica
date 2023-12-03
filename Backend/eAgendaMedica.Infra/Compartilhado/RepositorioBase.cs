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

        public virtual void Editar(TEntity registro)
        {
            this.dbset.Update(registro);
        }

        public virtual void Excluir(TEntity registro)
        {
            this.dbset.Remove(registro);
        }

        public virtual async Task InserirAsync(TEntity registro)
        {
            await this.dbset.AddAsync(registro);
        }

        public virtual async Task<TEntity> SelecionarPorIdAsync(Guid id)
        {
            return await this.dbset.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<TEntity>> SelecionarTodosAsync(Guid usuarioId)
        {
            return await dbset.Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
