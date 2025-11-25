using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Constantes;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.CDEP.ConsolidacaoSolicitacoesAcervos
{
    public class ExecutarConsolidacaoDasSolicitacoesDeAcervoUseCase : AbstractUseCase, IExecutarConsolidacaoDasSolicitacoesDeAcervoUseCase
    {
        public ExecutarConsolidacaoDasSolicitacoesDeAcervoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitCdep.ExecutarConsolidacaoDasSolicitacoesDeAcervo, Guid.NewGuid(), ExchangeSmeWorkers.CDEP));
            return true;
        }
    }
}
