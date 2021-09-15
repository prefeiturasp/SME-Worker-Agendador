﻿using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using SME.SGP.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.GoogleClassroom
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
