using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class SyncSerapEstudantesProvasTaiUseCase : ISyncSerapEstudantesProvasTaiUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesProvasTaiUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerap.ProvaTAISync, Guid.NewGuid()));
        }
    }
}
