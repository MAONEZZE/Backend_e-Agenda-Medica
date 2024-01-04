namespace eAgendaMedica.Api.Config
{
    public static class ValidacaoConfigExtension
    {
        public static void ConfigurarValidacao(this IServiceCollection service)
        {
            service.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = false;//serve para mascarar o erro
            });
        }
    }
}
