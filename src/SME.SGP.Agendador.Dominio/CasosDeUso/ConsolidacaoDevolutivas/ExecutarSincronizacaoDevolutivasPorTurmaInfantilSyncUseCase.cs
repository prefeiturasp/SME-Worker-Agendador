using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.ConsolidacaoDevolutivas
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
