﻿using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.ComponentesCurriculares
{
    public class SincronizarComponentesCurricularesUseCase : AbstractUseCase, ISincronizarComponentesCurricularesUseCase
    {
        public SincronizarComponentesCurricularesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SincronizarComponentesCurriculares, Guid.NewGuid()));
        }
    }
}
