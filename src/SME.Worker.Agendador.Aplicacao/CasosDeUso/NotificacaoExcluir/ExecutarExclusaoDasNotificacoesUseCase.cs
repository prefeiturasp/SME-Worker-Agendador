using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador
{
    public class ExecutarExclusaoDasNotificacoesUseCase : IExecutarExclusaoDasNotificacoesUseCase
    {
        private readonly IMediator _mediator;

        public ExecutarExclusaoDasNotificacoesUseCase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await _mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarExclusaoDasNotificacoes, Guid.NewGuid()));
        }
    }
}
