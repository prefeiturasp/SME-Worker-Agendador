using MediatR;
using SME.Worker.Agendador.Infra;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.GoogleClassroom
{
    public class SyncGsaGoogleClassroomUseCase : AbstractUseCase, ISyncGsaGoogleClassroomUseCase
    {
        private readonly GoogleClassroomSyncOptions googleClassroomSyncOptions;

        public SyncGsaGoogleClassroomUseCase(IMediator mediator, GoogleClassroomSyncOptions googleClassroomSyncOptions) : base(mediator)
        {
            this.googleClassroomSyncOptions = googleClassroomSyncOptions;
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SyncGsaGoogleClassroom, Guid.NewGuid()));

        }
    }
}
