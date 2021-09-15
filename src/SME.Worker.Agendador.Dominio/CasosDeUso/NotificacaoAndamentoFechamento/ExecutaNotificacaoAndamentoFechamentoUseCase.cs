using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoAndamentoFechamento
{
    public class ExecutaNotificacaoAndamentoFechamentoUseCase : AbstractUseCase, IExecutaNotificacaoAndamentoFechamentoUseCase
    {
        public ExecutaNotificacaoAndamentoFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoAndamentoFechamentoUseCase", "Rabbit - NotificacaoAndamentoFechamentoUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoAndamentoFechamento, Guid.NewGuid()));
        }
    }
}
