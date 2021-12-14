using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SME.Worker.Agendador.Hangfire.Configurations
{
    public class DashboardConfiguration
    {
        public static void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            var filter = new DashboardAuthorizationFilter(new SgpAuthAuthorizationFilterOptions(configuration));
            app.UseHangfireDashboard("/worker", new DashboardOptions()
            {
                IsReadOnlyFunc = filter.ReadOnly,
                Authorization = new[] { filter },
                StatsPollingInterval = 10000, // atualiza a cada 10s
            });
        }
    }
}
