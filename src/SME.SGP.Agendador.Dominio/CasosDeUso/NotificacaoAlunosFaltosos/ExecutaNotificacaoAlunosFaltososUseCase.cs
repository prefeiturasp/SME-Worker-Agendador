using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoAlunosFaltosos
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
