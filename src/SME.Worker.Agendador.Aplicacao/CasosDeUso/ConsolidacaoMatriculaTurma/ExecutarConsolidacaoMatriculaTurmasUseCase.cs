using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoMatriculaTurma
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
