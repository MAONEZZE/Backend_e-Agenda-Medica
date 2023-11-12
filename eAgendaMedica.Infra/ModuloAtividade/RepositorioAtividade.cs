using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Infra.Compartilhado;

namespace eAgendaMedica.Infra.ModuloAtividade
{
    public class RepositorioAtividade : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public RepositorioAtividade(IContextoPersistencia ctx) : base(ctx)
        {
        }
    }
}
