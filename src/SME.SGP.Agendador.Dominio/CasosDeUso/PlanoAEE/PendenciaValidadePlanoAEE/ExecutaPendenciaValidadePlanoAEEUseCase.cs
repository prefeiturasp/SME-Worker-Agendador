using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.PendenciaValidadePlanoAEE
{
    public class ExecutaPendenciaValidadePlanoAEEUseCase : AbstractUseCase, IExecutaPendenciaValidadePlanoAEEUseCase
    {
        public ExecutaPendenciaValidadePlanoAEEUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutaPendenciaValidadoPlanoAEEUseCase", "Rabbit - ExecutaPendenciaValidadoPlanoAEEUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.GerarPendenciaValidadePlanoAEE, Guid.NewGuid()));
        }
    }
}
