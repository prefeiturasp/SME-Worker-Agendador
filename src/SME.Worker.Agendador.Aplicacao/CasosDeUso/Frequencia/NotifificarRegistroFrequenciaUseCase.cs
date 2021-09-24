using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia
{
    public class NotifificarRegistroFrequenciaUseCase : AbstractUseCase, INotifificarRegistroFrequenciaUseCase
    {
        public NotifificarRegistroFrequenciaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotifificarRegistroFrequencia, Guid.NewGuid()));
        }
    }
}
