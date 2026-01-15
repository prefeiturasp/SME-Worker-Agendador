using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Constantes;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.CDEP.AtualizacaoSituacaoSolicitacao
{
    public class AtualizarSituacaoDasSolicitacoesDeAcervoVencidasUseCase : AbstractUseCase, IAtualizarSituacaoDasSolicitacoesDeAcervoVencidasUseCase
    {
        public AtualizarSituacaoDasSolicitacoesDeAcervoVencidasUseCase(IMediator mediator) : base(mediator)
        {

        }
        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitCdep.ExecutarAtualizacaoSituacaoDasSolicitacoesDeAcervoVencidas, Guid.NewGuid(), ExchangeSmeWorkers.CDEP));
            return true;
        }
    }
}
