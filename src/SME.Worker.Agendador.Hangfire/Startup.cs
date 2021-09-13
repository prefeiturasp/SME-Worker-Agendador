using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Hangfire.Configurations;

namespace SME.Worker.Agendador.Hangfire
{
    internal class Startup
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            var paramConnectionString = this.configuration.GetConnectionString("SGP_Postgres");
            this.connectionString = (!paramConnectionString.EndsWith(';') ? paramConnectionString + ";" : paramConnectionString) + "Application Name=SGP Worker Service Dashboard";
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            DashboardConfiguration.Configure(app, configuration);

        public void ConfigureServices(IServiceCollection services) =>
            WorkerConfiguration.Configure(services, this.connectionString);
    }
}