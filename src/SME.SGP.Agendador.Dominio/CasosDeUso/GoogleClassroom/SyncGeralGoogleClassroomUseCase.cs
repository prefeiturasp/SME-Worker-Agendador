﻿using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.GoogleClassroom
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
