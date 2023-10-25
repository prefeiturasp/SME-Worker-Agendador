using MediatR;
using System;
using System.Threading.Tasks;
using SME.Worker.Agendador.Infra;

namespace SME.Worker.Agendador.Aplicacao
{
    public class DownloadBackgroundUseCase : IDownloadBackgroundUseCase
    {
        private readonly IMediator mediator;

        public DownloadBackgroundUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerapEstudantes.WebPushTestSync, Guid.NewGuid()));
        }
    }
}
