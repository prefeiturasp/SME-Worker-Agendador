using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class ConsolidacaoDiariosBordoTurmasUseCase : AbstractUseCase, IConsolidacaoDiariosBordoTurmasUseCase
    {
        public ConsolidacaoDiariosBordoTurmasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidacaoDiariosBordoTurmasUseCase", "Rabbit - ConsolidacaoDiariosBordoTurmasUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidarDiariosBordoCarregar, string.Empty, Guid.NewGuid()));
        }
    }
}
