using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class SyncSerapEstudantesProvasBibUseCase : ISyncSerapEstudantesProvasBibUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesProvasBibUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSerap.ProvaBIBSync, Guid.NewGuid()));
        }
    }
}
