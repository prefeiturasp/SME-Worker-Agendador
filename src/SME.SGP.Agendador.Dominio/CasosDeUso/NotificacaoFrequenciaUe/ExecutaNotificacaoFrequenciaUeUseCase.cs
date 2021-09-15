using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoFrequenciaUe
{
    public class ExecutaNotificacaoFrequenciaUeUseCase : AbstractUseCase, IExecutaNotificacaoFrequenciaUeUseCase
    {
        public ExecutaNotificacaoFrequenciaUeUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb("Mensagem NotificacaoFrequenciaUe", "Rabbit - NotificacaoFrequenciaUe");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoFrequenciaUe, Guid.NewGuid()));
        }
    }
}
