using MediatR;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Worker.Agendador
{
    public class ExecutaNotificacaoNotaPosConselhoClasseUseCase : IExecutaNotificacaoNotaPosConselhoClasseUseCase
    {
        private readonly IMediator _mediator;

        public ExecutaNotificacaoNotaPosConselhoClasseUseCase(IMediator mediator)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await _mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaNotificacaoAprovacaoNotaPosConselho, Guid.NewGuid()));
        }

    }
}

