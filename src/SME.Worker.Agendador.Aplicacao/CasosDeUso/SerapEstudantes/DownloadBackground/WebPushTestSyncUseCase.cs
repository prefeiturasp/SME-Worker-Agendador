using MediatR;
using System;
using System.Threading.Tasks;
using SME.Worker.Agendador.Infra;

namespace SME.Worker.Agendador.Aplicacao
{
    public class WebPushTestSyncUseCase : IWebPushTestSyncUseCase
    {
        private readonly IMediator mediator;

        public WebPushTestSyncUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerapEstudantes.WebPushTestSync, Guid.NewGuid()));
        }
    }
}
