using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class ConsolidacaoReflexoFrequenciaBuscaAtivaUseCase : AbstractUseCase, IConsolidacaoReflexoFrequenciaBuscaAtivaUseCase
    {
        public ConsolidacaoReflexoFrequenciaBuscaAtivaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidacaoReflexoFrequenciaBuscaAtivaUseCase", "Rabbit - ConsolidacaoReflexoFrequenciaBuscaAtivaUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarReflexoFrequenciaBuscaAtiva, Guid.NewGuid()));
        }
    }
}
