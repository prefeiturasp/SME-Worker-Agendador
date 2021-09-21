using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaRegistroIndividual
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
