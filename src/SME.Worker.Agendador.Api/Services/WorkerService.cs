using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sentry;
using SME.SGP.Dados;
using SME.SGP.Dados.Mapeamentos;
using SME.SGP.Infra;
using SME.SGP.Infra.Utilitarios;
using SME.SGP.IoC;
using SME.SGP.IoC.Extensions;
using SME.Worker.Agendador.Api.Configuracoes;
using SME.Worker.Agendador.Background;
using SME.Worker.Agendador.Background.Core;
using SME.Worker.Agendador.Hangfire;
using SME.Worker.Agendador.Hangfire.Configurations;
using SME.Worker.Agendador.IoC;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Api.Services
{
    public class WorkerService : IHostedService
    {
        private static Servidor<Hangfire.Worker> HangfireWorkerService;
        private string ipLocal;

        protected string IPLocal
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ipLocal))
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipLocal = ip.ToString();
                        }
                    }

                    if (string.IsNullOrWhiteSpace(ipLocal))
                        ipLocal = "127.0.0.1";
                }

                return ipLocal;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            SentrySdk.AddBreadcrumb($"[SME SGP] Serviço Background iniciado no ip: {IPLocal}", "Service Life cycle");
            HangfireWorkerService.Registrar();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            HangfireWorkerService.Dispose();
            SentrySdk.AddBreadcrumb($"[SME SGP] Serviço Background finalizado no ip: {IPLocal}", "Service Life cycle");
            return Task.CompletedTask;
        }

        internal static void ConfigurarHangfire(IConfiguration configuration, IServiceCollection services)
        {
            HangfireWorkerService = new Servidor<Hangfire.Worker>(new Hangfire.Worker(configuration, services, configuration.GetConnectionString("SGP_Postgres")));
        }

        internal static void ConfigurarDependenciasApi(IConfiguration configuration, IServiceCollection services)
        {
            services.AddPolicies();

            services.AddRabbit();

            RegistraDependenciasWorkerServices.Registrar(services);
            RegistraDependencias.Registrar(services);
            RegistraDependenciasAgendador.Registrar(services);
            
            RegistraClientesHttp.Registrar(services, configuration);
            Orquestrador.Inicializar(services.BuildServiceProvider());
            
        }

        internal static void ConfigurarDependencias(IConfiguration configuration, IServiceCollection services)
        {
            RegistrarMapeamentos.Registrar();
            ConfigurarDependenciasApi(configuration, services);
        }

        internal static void ConfiguraVariaveisAmbiente(IServiceCollection services, IConfiguration configuration)
        {
            var configuracaoRabbitOptions = new ConfiguracaoRabbitOptions();
            configuration.GetSection(nameof(ConfiguracaoRabbitOptions)).Bind(configuracaoRabbitOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(configuracaoRabbitOptions);
        }

        internal static void ConfiguraGoogleClassroomSync(IServiceCollection services, IConfiguration configuration)
        {
            var googleClassroomSyncOptions = new GoogleClassroomSyncOptions();
            configuration.GetSection(nameof(GoogleClassroomSyncOptions)).Bind(googleClassroomSyncOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(googleClassroomSyncOptions);
        }

        internal static void Initialize(HostBuilderContext hostContext, IServiceCollection services) =>
            Initialize(hostContext.Configuration, services);

        internal static void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            services.AddHostedService<WorkerService>();
            WorkerService.ConfigurarDependenciasApi(configuration, services);
            WorkerService.ConfiguraVariaveisAmbiente(services, configuration);
            WorkerService.ConfiguraGoogleClassroomSync(services, configuration);
            WorkerService.ConfigurarHangfire(configuration, services);

            services.AddApplicationInsightsTelemetryWorkerService(configuration.GetValue<string>("ApplicationInsights__InstrumentationKey"));

            var provider = services.BuildServiceProvider();

            //services.AddSingleton<IConnectionMultiplexerSME>(
            //    new ConnectionMultiplexerSME(hostContext.Configuration.GetConnectionString("SGP_Redis"), provider.GetService<IServicoLog>()));

            Orquestrador.Registrar(new Processor(configuration, "SGP_Postgres"));
            RegistraServicosRecorrentes.Registrar();

            // Teste para injeção do client de telemetria em classe estática                 ,
            var telemetryConfiguration = new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration(configuration.GetValue<string>("ApplicationInsights:InstrumentationKey"));
            var telemetryClient = new TelemetryClient(telemetryConfiguration);
            DapperExtensionMethods.Init(telemetryClient);

            services.AddMemoryCache();
        }
    }
}

