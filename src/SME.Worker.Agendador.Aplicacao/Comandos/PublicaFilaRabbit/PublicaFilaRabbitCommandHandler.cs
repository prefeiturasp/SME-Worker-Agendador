using MediatR;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.Handlers
{
    public class PublicaFilaRabbitCommandHandler : IRequestHandler<PublicaFilaRabbitCommand, bool>
    {

        private readonly IAsyncPolicy policy;
        private readonly IConnection conexaoRabbit;

        public PublicaFilaRabbitCommandHandler(IReadOnlyPolicyRegistry<string> registry, IConnection conexaoRabbit)
        {

            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PublicaFila);
            this.conexaoRabbit = conexaoRabbit ?? throw new ArgumentNullException(nameof(conexaoRabbit));
        }

        public async Task<bool> Handle(PublicaFilaRabbitCommand command, CancellationToken cancellationToken)
        {
            var request = new MensagemRabbit(command.Filtros,
                                             command.CodigoCorrelacao,
                                             command.UsuarioLogadoNomeCompleto,
                                             command.UsuarioLogadoRF,
                                             command.PerfilUsuario,
                                             command.NotificarErroUsuario);

            var mensagem = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var body = Encoding.UTF8.GetBytes(mensagem);

            await policy.ExecuteAsync(async () => await PublicarMensagem(command.Rota, body, command.Exchange));

            return true;
        }

        private async Task PublicarMensagem(string rota, byte[] body, string exchange)
        {
            using IModel _channel = conexaoRabbit.CreateModel();
            var props = _channel.CreateBasicProperties();
            props.Persistent = true;
            await Task.Run(() => _channel.BasicPublish(exchange, rota, props, body));
        }
    }
}
