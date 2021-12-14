using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais
{
    public class ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase : AbstractUseCase, IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase
    {
        public ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase", "Rabbit - ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarMediaRegistrosIndividuaisTurma, string.Empty, Guid.NewGuid()));
        }
    }
}
