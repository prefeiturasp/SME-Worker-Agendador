using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep
{
    public class ExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase : IExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase
    {
        private readonly IMediator mediator;

        public ExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitCdep.ExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtraso, Guid.NewGuid()));
        }
    }
}
