using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEExpirado
{
    public class ExecutaNotificacaoPlanoAEEExpiradoUseCase : AbstractUseCase, IExecutaNotificacaoPlanoAEEExpiradoUseCase
    {
        public ExecutaNotificacaoPlanoAEEExpiradoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutaNotificacaoPlanoAEEExpiradoUseCase", "Rabbit - ExecutaNotificacaoPlanoAEEExpiradoUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.NotificarPlanoAEEExpirado, Guid.NewGuid()));
        }
    }
}
