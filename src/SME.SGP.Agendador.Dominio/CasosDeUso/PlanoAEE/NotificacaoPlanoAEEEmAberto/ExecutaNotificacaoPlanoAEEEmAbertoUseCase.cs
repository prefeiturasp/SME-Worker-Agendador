using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEEmAberto
{
    public class ExecutaNotificacaoPlanoAEEEmAbertoUseCase : AbstractUseCase, IExecutaNotificacaoPlanoAEEEmAbertoUseCase
    {
        public ExecutaNotificacaoPlanoAEEEmAbertoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutaNotificacaoPlanoAEEEmAbertoUseCase", "Rabbit - ExecutaNotificacaoPlanoAEEEmAbertoUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificarPlanoAEEEmAberto, Guid.NewGuid()));
        }
    }
}
