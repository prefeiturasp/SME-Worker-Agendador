using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Infra.Utilitarios;
using Hangfire.Redis;


namespace SME.Worker.Agendador.Hangfire.Configurations
{
    public class WorkerConfiguration
    {
        public static void Configure(IServiceCollection services, ConfiguracaoHangfireOptions configuracaoHangfireOptions)
        {
            var options = new RedisStorageOptions(){ Db = configuracaoHangfireOptions.RedisDbNumber };

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 })
            .UseRedisStorage(configuracaoHangfireOptions.ConnectionString, options));
        }
    }
}
