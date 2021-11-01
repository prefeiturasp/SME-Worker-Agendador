using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoRegistrosPedagogicos
{
    public class ExecutarConsolidacaoRegistrosPedagogicosUseCase : AbstractUseCase, IExecutarConsolidacaoRegistrosPedagogicosUseCase
    {
        public ExecutarConsolidacaoRegistrosPedagogicosUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarConsolidacaoRegistrosPedagogicosUseCase", "Rabbit - ExecutarConsolidacaoRegistrosPedagogicosUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidarRegistrosPedagogicos, string.Empty, Guid.NewGuid()));
        }
    }
}
