using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.GoogleClassroom
{
    public class SyncGeralGoogleClassroomUseCase : ISyncGeralGoogleClassroomUseCase
    {
        protected readonly IMediator mediator;

        public SyncGeralGoogleClassroomUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SyncGeralGoogleClassroom, Guid.NewGuid()));
        }
    }
}
