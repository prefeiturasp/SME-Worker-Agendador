using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoInicioFimPeriodoFechamento
{
    public class ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase : AbstractUseCase, IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase
    {
        public ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoInicioFimPeriodoFechamento", "Rabbit - NotificacaoInicioFimPeriodoFechamento");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoInicioFimPeriodoFechamento, Guid.NewGuid()));
        }
    }
}
