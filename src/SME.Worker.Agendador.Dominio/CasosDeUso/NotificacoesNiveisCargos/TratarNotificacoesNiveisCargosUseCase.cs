using MediatR;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacoesNiveisCargos
{
    public class TratarNotificacoesNiveisCargosUseCase : ITratarNotificacoesNiveisCargosUseCase
    {
        private readonly IMediator mediator;

        public TratarNotificacoesNiveisCargosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.TratarNotificacoesNiveisCargos, Guid.NewGuid()));
        }
    }
}
