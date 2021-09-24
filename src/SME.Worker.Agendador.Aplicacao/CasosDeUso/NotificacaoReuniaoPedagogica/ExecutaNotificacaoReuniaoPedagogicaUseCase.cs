using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoReuniaoPedagogica
{
    public class ExecutaNotificacaoReuniaoPedagogicaUseCase : AbstractUseCase, IExecutaNotificacaoReuniaoPedagogicaUseCase
    {
        public ExecutaNotificacaoReuniaoPedagogicaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoReuniaoPedagogica", "Rabbit - NotificacaoReuniaoPedagogica");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoReuniaoPedagogica, Guid.NewGuid()));
        }
    }
}
