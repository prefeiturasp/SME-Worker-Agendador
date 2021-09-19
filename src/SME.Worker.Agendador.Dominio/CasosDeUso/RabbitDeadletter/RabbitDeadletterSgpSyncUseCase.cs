﻿using MediatR;
using SME.SGP.Infra.Utilitarios;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.RabbitDeadletter
{
    public class RabbitDeadletterSgpSyncUseCase : IRabbitDeadletterSgpSyncUseCase
    {
        private readonly IMediator mediator;

        public RabbitDeadletterSgpSyncUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            foreach (var fila in typeof(RotasRabbitSgp).ObterConstantesPublicas<string>())
            {
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaRabbitDeadletterTratar, fila, Guid.NewGuid()));
            }

            return true;
        }
    }
}
