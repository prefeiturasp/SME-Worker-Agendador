using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoMatriculaTurma
{
    public class ExecutarConsolidacaoMatriculaTurmasUseCase : AbstractUseCase, IExecutarConsolidacaoMatriculaTurmasUseCase
    {
        public ExecutarConsolidacaoMatriculaTurmasUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarConsolidacaoFrequenciaTurmaSyncUseCase", "Rabbit - ExecutarConsolidacaoFrequenciaTurmaSyncUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidacaoMatriculasTurmasDreCarregar, string.Empty, Guid.NewGuid()));
        }
    }
}
