using MediatR;
using SME.Worker.Agendador.Infra;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class TratarDeadletterSerapAcompanhamentoSyncUseCase : ITratarDeadletterSerapAcompanhamentoSyncUseCase
    {

        protected readonly IMediator mediator;

        public TratarDeadletterSerapAcompanhamentoSyncUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapAcompanhamentoCommand(RotasRabbitSerapAcompanhamento.DeadLetterSync, Guid.NewGuid()));
        }
    }
}
