using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class SyncSerapEstudantesQuestaoCompletaUseCase : ISyncSerapEstudantesQuestaoCompletaUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesQuestaoCompletaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerap.QuestaoCompletaSync, Guid.NewGuid()));
        }
    }
}
