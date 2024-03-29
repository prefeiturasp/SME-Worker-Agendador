﻿using Hangfire;
using MediatR;
using System;

namespace SME.Worker.Agendador.Hangfire
{
    public class HangfireActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator mediator;

        public HangfireActivator(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override object ActivateJob(Type jobType)
        {
            if (jobType.Name == "HangfireMediator")
            {
                return mediator;
            }
            else
            {
                return _serviceProvider.GetService(jobType);
            }
        }
    }
}
