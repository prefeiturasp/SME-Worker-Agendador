using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.SincronizacaoInstitucional
{
    public class ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase : AbstractUseCase, IExecutarSincronizacaoInstitucionalSyncUseCase
    {
        public ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            var codigoCorrelacao = Guid.NewGuid();

            SentrySdk.AddBreadcrumb($"Mensagem ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase", "Rabbit - ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizaEstruturaInstitucionalDreSync, string.Empty, codigoCorrelacao));

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizaEstruturaInstitucionalTipoEscolaSync, string.Empty, codigoCorrelacao));

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizaEstruturaInstitucionalCicloSync, string.Empty, codigoCorrelacao));
        }
    }
}
