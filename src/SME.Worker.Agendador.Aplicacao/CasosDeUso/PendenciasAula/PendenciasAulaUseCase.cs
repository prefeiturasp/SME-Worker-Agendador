using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasAula
{
    public class PendenciasAulaUseCase : IPendenciasAulaUseCase
    {
        private readonly IMediator mediator;

        public PendenciasAulaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutaPendenciasAula, Guid.NewGuid()));
        }
    }
}
