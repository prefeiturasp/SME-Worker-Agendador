using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Worker.Agendador.Hangfire.Configurations
{
    public class WorkerConfiguration
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 })
            .UseRedisStorage(connectionString));
        }
    }
}
