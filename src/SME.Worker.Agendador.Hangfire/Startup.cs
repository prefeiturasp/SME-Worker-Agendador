using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SME.Worker.Agendador.Hangfire.Configurations;
using SME.Worker.Agendador.IoC.Extensions;

namespace SME.Worker.Agendador.Hangfire
{
    internal class Startup
    {
        public IConfiguration Configuration { get; set; }
        public string ConnectionString { get; set; }

        public Startup()
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            DashboardConfiguration.Configure(app, this.Configuration);

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRabbit(Configuration);
        }
            
    }
}