using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace SME.Worker.Agendador.IoC.Extensions
{
    public static class RegistrarRabbit
    {
        public static void AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("ConfiguracaoRabbitOptions:Hostname").Value,
                UserName = configuration.GetSection("ConfiguracaoRabbitOptions:Username").Value,
                Password = configuration.GetSection("ConfiguracaoRabbitOptions:Password").Value,
                VirtualHost = configuration.GetSection("ConfiguracaoRabbitOptions:Virtualhost").Value
            };

            var conexaoRabbit = factory.CreateConnection();

            services.AddSingleton(conexaoRabbit);
        }
    }
}
