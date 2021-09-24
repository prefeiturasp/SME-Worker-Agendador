using Hangfire;
using MediatR;
using System;

namespace SME.Worker.Agendador.Hangfire
{
    public class MediatRJobActivator : JobActivator
    {
        private readonly IMediator mediator;

        public MediatRJobActivator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override object ActivateJob(Type type)
        {
            return mediator;
        }
    }
}
