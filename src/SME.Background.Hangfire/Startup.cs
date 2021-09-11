﻿using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Background.Hangfire
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            var paramConnectionString = this.configuration.GetConnectionString("SGP_Postgres");
            this.connectionString = (!paramConnectionString.EndsWith(';') ? paramConnectionString + ";" : paramConnectionString) + "Application Name=SGP Worker Service Dashboard";
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var filter = new DashboardAuthorizationFilter(new SgpAuthAuthorizationFilterOptions(configuration));
            app.UseHangfireDashboard("/worker", new DashboardOptions()
            {
                IsReadOnlyFunc = filter.ReadOnly,
                Authorization = new[] { filter },
                StatsPollingInterval = 10000, // atualiza a cada 10s
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 }));
            // Todo: Alterar para redis
            //.UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions()
            //{
            //    SchemaName = "hangfire"
            //}));
        }
    }
}