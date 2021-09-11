using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SGP.Worker.Agendador.Service.HealthCheck
{
    public class ApiAgendadorCheck : IHealthCheck
    {
        private readonly IConfiguration configuration;

        public ApiAgendadorCheck(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var clienteHttp = new HttpClient();
                var result = clienteHttp.GetAsync(configuration.GetSection("UrlApiAgendador").Value).Result;

                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult(HealthCheckResult.Healthy("O serviço está respondendo normalmente."));
                }

                return Task.FromResult(HealthCheckResult.Unhealthy("O serviço apresenta problemas."));
            }
            catch (System.Exception)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("O serviço apresenta problemas."));
            }
        }
    }
}
