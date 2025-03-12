using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SME.Worker.Agendador.Infra;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SME.Worker.Agendador.Aplicacao.Comandos.PublicarFilaSerapBoletim
{
    public class PublicarFilaSerapBoletimCommandHandler : IRequestHandler<PublicarFilaSerapBoletimCommand, bool>
    {
        private readonly IConnection conexaoRabbit;

        public PublicarFilaSerapBoletimCommandHandler(IConnection conexaoRabbit)
        {
            this.conexaoRabbit = conexaoRabbit ?? throw new System.ArgumentNullException(nameof(conexaoRabbit));
        }

        public Task<bool> Handle(PublicarFilaSerapBoletimCommand request, CancellationToken cancellationToken)
        {
            using (IModel _channel = conexaoRabbit.CreateModel())
            {
                var mensagem = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                byte[] body = FormataBodyWorker(request);

                _channel.BasicPublish(RotasRabbitSerapBoletim.ExchangeSerapBoletim, request.Fila, null, body);
            }

            return Task.FromResult(true);
        }

        private static byte[] FormataBodyWorker(PublicarFilaSerapBoletimCommand request)
        {
            var mensagem = new MensagemRabbit(request.Mensagem);
            var mensagemJson = JsonConvert.SerializeObject(mensagem);
            var body = Encoding.UTF8.GetBytes(mensagemJson);
            return body;
        }
    }
}
