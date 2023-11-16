namespace eAgendaMedica.Infra.Compartilhado
{
    public class MigradorDb
    {
        public static bool AtualizarDb(DbContext eAgendaDb)
        {
            int qtdMigracoesPendentes = eAgendaDb.Database.GetPendingMigrations().Count();

            if (qtdMigracoesPendentes == 0)
            {
                return false;
            }

            eAgendaDb.Database.Migrate();

            return qtdMigracoesPendentes > 0;
        }
    }
}
