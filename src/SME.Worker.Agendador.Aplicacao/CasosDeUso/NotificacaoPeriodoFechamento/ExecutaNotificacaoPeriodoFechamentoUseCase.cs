using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoPeriodoFechamento
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
