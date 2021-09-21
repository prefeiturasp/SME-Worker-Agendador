using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos
{
    public class ExecutaNotificacaoAlunosFaltososUseCase : AbstractUseCase, IExecutaNotificacaoAlunosFaltososUseCase
    {
        public ExecutaNotificacaoAlunosFaltososUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb("Mensagem NotificacaoAlunosFaltosos", "Rabbit - NotificacaoAlunosFaltosos");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoAlunosFaltosos, Guid.NewGuid()));
        }
    }
}
