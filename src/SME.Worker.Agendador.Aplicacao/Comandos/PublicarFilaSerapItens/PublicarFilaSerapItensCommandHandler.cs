using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SME.Worker.Agendador.Infra;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class PublicarFilaSerapItensCommandHandler : IRequestHandler<PublicarFilaSerapItensCommand, bool>
    {
        private readonly IConnection conexaoRabbit;

        public PublicarFilaSerapItensCommandHandler(IConnection conexaoRabbit)
        {
            this.conexaoRabbit = conexaoRabbit ?? throw new System.ArgumentNullException(nameof(conexaoRabbit));
        }

        public Task<bool> Handle(PublicarFilaSerapItensCommand request, CancellationToken cancellationToken)
        {
            using (IModel _channel = conexaoRabbit.CreateModel())
            {
                var mensagem = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                byte[] body = FormataBodyWorker(request);

                _channel.BasicPublish(RotasRabbitSerapItens.ExchangeSerapItens, request.Fila, null, body);
            }

            return Task.FromResult(true);
        }

        private static byte[] FormataBodyWorker(PublicarFilaSerapItensCommand request)
        {
            var mensagem = new MensagemRabbit(request.Mensagem);
            var mensagemJson = JsonConvert.SerializeObject(mensagem);
            var body = Encoding.UTF8.GetBytes(mensagemJson);
            return body;
        }
    }
}
