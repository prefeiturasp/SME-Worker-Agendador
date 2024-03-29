﻿using MediatR;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Worker.Agendador
{
    public class ExecutaNotificacaoAprovacaoFechamentoNotaUseCase : IExecutaNotificacaoAprovacaoFechamentoNotaUseCase
    {
        private readonly IMediator _mediator;

        public ExecutaNotificacaoAprovacaoFechamentoNotaUseCase(IMediator mediator)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await _mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaNotificacaoAprovacaoFechamento, Guid.NewGuid()));
        }

    }
}

