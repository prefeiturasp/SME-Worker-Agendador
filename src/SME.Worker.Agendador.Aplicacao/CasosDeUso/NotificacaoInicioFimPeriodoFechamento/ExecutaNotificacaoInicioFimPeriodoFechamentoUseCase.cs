using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoInicioFimPeriodoFechamento
{
    public class ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase : AbstractUseCase, IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase
    {
        public ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoInicioFimPeriodoFechamento", "Rabbit - NotificacaoInicioFimPeriodoFechamento");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaNotificacaoInicioFimPeriodoFechamento, Guid.NewGuid()));
        }
    }
}
