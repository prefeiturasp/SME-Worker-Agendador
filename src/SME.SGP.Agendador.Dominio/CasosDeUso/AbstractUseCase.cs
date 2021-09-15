using MediatR;
using System;

namespace SME.SGP.Agendador.Dominio.CasosDeUso
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
