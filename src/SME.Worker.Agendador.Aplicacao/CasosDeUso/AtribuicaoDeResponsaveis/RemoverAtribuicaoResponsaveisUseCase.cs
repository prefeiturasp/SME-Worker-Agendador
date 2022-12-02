using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class RemoverAtribuicaoResponsaveisUseCase : IRemoverAtribuicaoResponsaveisUseCase
    {
        private readonly IMediator _mediator;

        public RemoverAtribuicaoResponsaveisUseCase(IMediator mediator)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await _mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaRemoverAtribuicaoDeResponsaveis, Guid.NewGuid()));
        }
   
    }
}
