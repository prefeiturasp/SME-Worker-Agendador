using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoFrequenciaTurma
{
    public class ExecutarConsolidacaoFrequenciaTurmaSyncUseCase : AbstractUseCase, IExecutarConsolidacaoFrequenciaTurmaSyncUseCase
    {
        public ExecutarConsolidacaoFrequenciaTurmaSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarConsolidacaoFrequenciaTurmaSyncUseCase", "Rabbit - ExecutarConsolidacaoFrequenciaTurmaSyncUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidacaoFrequenciasTurmasCarregar, string.Empty, Guid.NewGuid()));
        }
    }
}
