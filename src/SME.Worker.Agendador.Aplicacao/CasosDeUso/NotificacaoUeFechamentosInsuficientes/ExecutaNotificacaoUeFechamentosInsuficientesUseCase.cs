using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoUeFechamentosInsuficientes
{
    public class ExecutaNotificacaoUeFechamentosInsuficientesUseCase : AbstractUseCase, IExecutaNotificacaoUeFechamentosInsuficientesUseCase
    {
        public ExecutaNotificacaoUeFechamentosInsuficientesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem NotificacaoUeFechamentosInsuficientesUseCase", "Rabbit - NotificacaoUeFechamentosInsuficientesUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoUeFechamentosInsuficientes, Guid.NewGuid()));
        }
    }
}
