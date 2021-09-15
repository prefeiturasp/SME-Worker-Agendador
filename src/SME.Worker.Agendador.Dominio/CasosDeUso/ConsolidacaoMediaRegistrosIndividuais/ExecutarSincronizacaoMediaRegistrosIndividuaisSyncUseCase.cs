using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais
{
    public class ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase : AbstractUseCase, IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase
    {
        public ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase", "Rabbit - ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ConsolidarMediaRegistrosIndividuaisTurma, string.Empty, Guid.NewGuid()));
        }
    }
}
