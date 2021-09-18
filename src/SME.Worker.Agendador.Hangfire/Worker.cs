using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Background;
using SME.Worker.Agendador.Background.Core.Interfaces;
using SME.Worker.Agendador.Hangfire.Configurations;
using SME.Worker.Agendador.Hangfire.Logging;
using System;
using System.IO;

namespace SME.Worker.Agendador.Hangfire
{
    public class Worker : IWorker
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly IServiceCollection serviceCollection;
        private BackgroundJobServer hangFireServer;
        private IWebHost host;

        public Worker(IConfiguration configuration, IServiceCollection serviceCollection, string connectionString)
        {
            this.configuration = configuration;
            this.serviceCollection = serviceCollection;
            this.connectionString = (!connectionString.EndsWith(';') ? connectionString + ";" : connectionString) + "Application Name=SGP Worker Service";
        }

        public void Dispose()
        {
            host?.Dispose();
            hangFireServer.Dispose();
        }

        public void Registrar()
        {
            RegistrarHangfireServer();
            RegistrarDashboard();

            //EXEMPLO DE ADICIONAR ITENS NA FILA VIA JSON
            //var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"files\\{"job.json"}");
            //var JSON = System.IO.File.ReadAllText(folderDetails);
            //dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            //foreach (var item in jsonObj)
            //{
            //    try
            //    {
            //        BackgroundJob.Requeue(item.id.ToString(), "Failed");
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
        }

        private void RegistrarDashboard()
        {
            host = new WebHostBuilder()
                           .UseKestrel()
                           .UseContentRoot(Directory.GetCurrentDirectory())
                           .ConfigureAppConfiguration((hostContext, config) =>
                           {
                               config.SetBasePath(Directory.GetCurrentDirectory());
                               config.AddEnvironmentVariables();
                           })
                           .UseStartup<Startup>()
                           .UseUrls(UriConfiguration.GetUrls())
                           .Build();

            host.RunAsync();
        }

        private void RegistrarHangfireServer()
        {
            var pollInterval = configuration.GetValue<int>("BackgroundWorkerQueuePollInterval", 5);
            Console.WriteLine($"SGP Worker Service - BackgroundWorkerQueuePollInterval parameter = {pollInterval}");

            var assemblyApi = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Api");
            var assemblyApplication = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Aplicacao");
            var assemblyDomain = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Dominio");
            serviceCollection.AddMediatR(assemblyApi, assemblyApplication, assemblyDomain);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));


            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseLogProvider<SentryLogProvider>(new SentryLogProvider())
                .UseRecommendedSerializerSettings()
                .UseActivator(new HangfireActivator(serviceCollection.BuildServiceProvider(), mediator))
                .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 })
            // Todo: Alterar para redis
            .UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions()
            {
                QueuePollInterval = TimeSpan.FromSeconds(pollInterval),
                SchemaName = "hangfire"
            });

            GlobalJobFilters.Filters.Add(new ContextFilterAttribute());

            var workerCount = configuration.GetValue<int>("BackgroundWorkerParallelDegree", 1);
            Console.WriteLine($"SGP Worker Service - BackgroundWorkerParallelDegree parameter = {workerCount}");

            hangFireServer = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                WorkerCount = workerCount,
                Queues = new[] { "sgp", "default" }
            });
        }
    }
}

//