﻿using MediatR;
using System;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso
{
    public abstract class AbstractUseCase
    {
        protected readonly IMediator mediator;

        public AbstractUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
