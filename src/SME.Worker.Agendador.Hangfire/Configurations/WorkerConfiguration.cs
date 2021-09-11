using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Worker.Agendador.Hangfire.Configurations
{
    internal class WorkerConfiguration
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()  
            .UseRecommendedSerializerSettings()
            .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 })
            // Todo: Alterar para redis
            .UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions()
            {
                SchemaName = "hangfire"
            }));
        }
    }
}
