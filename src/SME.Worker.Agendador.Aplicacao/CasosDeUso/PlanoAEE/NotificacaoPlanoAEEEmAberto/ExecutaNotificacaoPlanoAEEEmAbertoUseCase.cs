using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEEmAberto
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
