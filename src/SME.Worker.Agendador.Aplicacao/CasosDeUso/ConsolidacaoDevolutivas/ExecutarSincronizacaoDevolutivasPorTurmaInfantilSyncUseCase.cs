using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoDevolutivas
{
    public class ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase : AbstractUseCase, IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase
    {
        public ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase", "Rabbit - ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidarDevolutivasPorTurmaInfantil, string.Empty, Guid.NewGuid()));
        }
    }
}
