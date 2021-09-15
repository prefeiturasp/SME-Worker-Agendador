using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoResultadoInsatisfatorio
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
