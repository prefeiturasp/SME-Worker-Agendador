using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class ConsolidacaoInformacoesProdutividadeFrequenciaUseCase : AbstractUseCase, IConsolidacaoInformacoesProdutividadeFrequenciaUseCase
    {
        public ConsolidacaoInformacoesProdutividadeFrequenciaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidacaoInformacoesProdutividadeFrequenciaUseCase", "Rabbit - ConsolidacaoInformacoesProdutividadeFrequenciaUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarInformacoesProdutividadeFrequencia, Guid.NewGuid()));
        }
    }
}
