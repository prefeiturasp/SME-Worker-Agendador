using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoUeFechamentosInsuficientes
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
