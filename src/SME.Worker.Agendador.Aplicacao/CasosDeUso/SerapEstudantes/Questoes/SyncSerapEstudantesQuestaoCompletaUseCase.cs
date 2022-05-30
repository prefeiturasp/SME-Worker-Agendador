using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
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
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSerap.QuestaoCompletaSync, Guid.NewGuid()));
        }
    }
}
