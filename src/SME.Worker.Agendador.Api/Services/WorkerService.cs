using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SME.Worker.Agendador.Background;
using SME.Worker.Agendador.Background.Core;
using SME.Worker.Agendador.Hangfire;
using SME.Worker.Agendador.Infra;
using SME.Worker.Agendador.Infra.Utilitarios;
using SME.Worker.Agendador.IoC;
using SME.Worker.Agendador.IoC.Extensions;
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
                    {
                        ipLocal = "127.0.0.1";
                    }
                }

                return ipLocal;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            HangfireWorkerService.Dispose();
            return Task.CompletedTask;
        }

        internal static void ConfigurarHangfire(IServiceCollection services, ConfiguracaoHangfireOptions configuracaoHangfireOptions)
        {
            HangfireWorkerService = new Servidor<Hangfire.Worker>(new Hangfire.Worker(services, configuracaoHangfireOptions));
        }

        internal static void ConfigurarDependenciasApi(IServiceCollection services)
        {
            services.AddPolicies();
            RegistraDependenciasWorkerServices.Registrar(services);
            Orquestrador.Inicializar(services.BuildServiceProvider());
        }


        internal static void ConfiguraVariaveisAmbiente(IServiceCollection services, IConfiguration configuration)
        {
            var configuracaoRabbitOptions = new ConfiguracaoRabbitOptions();
            configuration.GetSection(nameof(ConfiguracaoRabbitOptions)).Bind(configuracaoRabbitOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(configuracaoRabbitOptions);
        }

        internal static void ConfiguraGoogleClassroomSync(IServiceCollection services, IConfiguration configuration)
        {
            
        }

        internal static void Initialize(IServiceCollection services, ConfiguracaoHangfireOptions configuracaoHangfireOptions, ConfiguracaoRabbitOptions configuracaoRabbitOptions)
        {
            services.AddHostedService<WorkerService>();
            WorkerService.ConfigurarDependenciasApi(services);                        
            WorkerService.ConfigurarHangfire(services, configuracaoHangfireOptions);            

            Orquestrador.Registrar(new Processor(configuracaoHangfireOptions.ConnectionString));
            RegistraServicosRecorrentes.Registrar();

            services.AddMemoryCache();

            HangfireWorkerService.Registrar();
        }
    }
}

