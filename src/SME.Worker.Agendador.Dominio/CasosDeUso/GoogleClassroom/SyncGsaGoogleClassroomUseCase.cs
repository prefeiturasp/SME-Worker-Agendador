using MediatR;
using SME.SGP.Infra;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.GoogleClassroom
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
