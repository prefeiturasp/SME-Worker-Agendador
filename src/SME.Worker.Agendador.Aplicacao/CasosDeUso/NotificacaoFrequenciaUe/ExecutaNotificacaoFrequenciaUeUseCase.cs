using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoFrequenciaUe
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
