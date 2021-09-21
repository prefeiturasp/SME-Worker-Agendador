using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoResultadoInsatisfatorio
{
    public class ExecutaNotificacaoResultadoInsatisfatorioUseCase : AbstractUseCase, IExecutaNotificacaoResultadoInsatisfatorioUseCase
    {
        public ExecutaNotificacaoResultadoInsatisfatorioUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoResultadoInsatisfatorioUseCase", "Rabbit - NotificacaoResultadoInsatisfatorioUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoResultadoInsatisfatorio, Guid.NewGuid()));
        }
    }
}
