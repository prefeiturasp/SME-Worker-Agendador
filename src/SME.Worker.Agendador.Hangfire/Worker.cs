﻿using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Background;
using SME.Worker.Agendador.Background.Core.Interfaces;
using SME.Worker.Agendador.Infra.Utilitarios;
using System;
using System.IO;

namespace SME.Worker.Agendador.Hangfire
{
    public class Worker : IWorker
    {
        private readonly ConfiguracaoHangfireOptions configuracaoHangfireOptions;
        private readonly IServiceCollection serviceCollection;
        private BackgroundJobServer hangFireServer;
        private readonly IWebHost host;

        public Worker(IServiceCollection serviceCollection, ConfiguracaoHangfireOptions configuracaoHangfireOptions)
        {
            
            this.serviceCollection = serviceCollection;            
            this.configuracaoHangfireOptions = configuracaoHangfireOptions ?? throw new ArgumentNullException(nameof(configuracaoHangfireOptions));
        }

        public void Dispose()
        {
            host?.Dispose();
            hangFireServer.Dispose();
        }

        public void Registrar()
        {
            RegistrarHangfireServer();
        }

        private void RegistrarHangfireServer()
        {
            var pollInterval = configuracaoHangfireOptions.BackgroundWorkerQueuePollInterval;
            Console.WriteLine($"SGP Worker Service - BackgroundWorkerQueuePollInterval parameter = {pollInterval}");

            var assemblyApi = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Api");
            var assemblyApplication = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Aplicacao");
            var assemblyDomain = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Aplicacao");
            serviceCollection.AddMediatR(assemblyApi, assemblyApplication, assemblyDomain);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));


            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseActivator(new HangfireActivator(serviceCollection.BuildServiceProvider(), mediator))
                .UseFilter<AutomaticRetryAttribute>(new AutomaticRetryAttribute() { Attempts = 0 })
                .UseRedisStorage(configuracaoHangfireOptions.ConnectionString);

            GlobalJobFilters.Filters.Add(new ContextFilterAttribute());

            var workerCount = configuracaoHangfireOptions.BackgroundWorkerParallelDegree;
            Console.WriteLine($"SGP Worker Service - BackgroundWorkerParallelDegree parameter = {workerCount}");

            hangFireServer = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                WorkerCount = workerCount,
                Queues = new[] { "sgp" }
            });
        }
    }
}

//