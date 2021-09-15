using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.PendenciaRegistroIndividual
{
    public class PublicarPendenciaAusenciaRegistroIndividualUseCase : AbstractUseCase, IPublicarPendenciaAusenciaRegistroIndividualUseCase
    {
        public PublicarPendenciaAusenciaRegistroIndividualUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem {nameof(PublicarPendenciaAusenciaRegistroIndividualUseCase)}", $"Rabbit - {nameof(PublicarPendenciaAusenciaRegistroIndividualUseCase)}");
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaPendenciaAusenciaRegistroIndividual, Guid.NewGuid()));
        }
    }
}
