using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoFrequenciaTurma
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
