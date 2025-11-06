using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Constantes;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep
{
    public class ExecutarConsolidacaoDoHistoricoDeConsultasDeAcervoUseCase : AbstractUseCase, IExecutarConsolidacaoDoHistoricoDeConsultasDeAcervoUseCase
    {
        public ExecutarConsolidacaoDoHistoricoDeConsultasDeAcervoUseCase(IMediator mediator) : base(mediator)
        { }
        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitCdep.ExecutarConsolidacaoDoHistoricoDeConsultasDeAcervo, Guid.NewGuid(), ExchangeSmeWorkers.CDEP));
            return true;
        }
    }
}