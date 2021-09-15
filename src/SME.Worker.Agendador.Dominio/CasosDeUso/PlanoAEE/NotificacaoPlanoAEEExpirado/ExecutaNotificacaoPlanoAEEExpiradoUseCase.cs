using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEExpirado
{
    public class ExecutaNotificacaoPlanoAEEExpiradoUseCase : AbstractUseCase, IExecutaNotificacaoPlanoAEEExpiradoUseCase
    {
        public ExecutaNotificacaoPlanoAEEExpiradoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutaNotificacaoPlanoAEEExpiradoUseCase", "Rabbit - ExecutaNotificacaoPlanoAEEExpiradoUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificarPlanoAEEExpirado, Guid.NewGuid()));
        }
    }
}
