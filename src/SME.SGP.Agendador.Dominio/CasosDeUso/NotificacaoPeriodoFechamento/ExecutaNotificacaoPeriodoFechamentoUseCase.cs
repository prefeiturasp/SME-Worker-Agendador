using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoPeriodoFechamento
{
    public class ExecutaNotificacaoPeriodoFechamentoUseCase : AbstractUseCase, IExecutaNotificacaoPeriodoFechamentoUseCase
    {
        public ExecutaNotificacaoPeriodoFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoPeriodoFechamento", "Rabbit - NotificacaoPeriodoFechamento");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoPeriodoFechamento, Guid.NewGuid()));
        }
    }
}
