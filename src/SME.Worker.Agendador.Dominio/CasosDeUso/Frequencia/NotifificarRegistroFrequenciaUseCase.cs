﻿using MediatR;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.Frequencia
{
    public class NotifificarRegistroFrequenciaUseCase : AbstractUseCase, INotifificarRegistroFrequenciaUseCase
    {
        public NotifificarRegistroFrequenciaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotifificarRegistroFrequencia, Guid.NewGuid()));
        }
    }
}