using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;
using SME.Worker.Agendador.Aplicacao.Constantes;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep
{
    public class NotificacaoDevolucaoEmprestimoAtrasoProlongadoUseCase : AbstractUseCase, INotificacaoDevolucaoEmprestimoAtrasoProlongadoUseCase
    {
        public NotificacaoDevolucaoEmprestimoAtrasoProlongadoUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitCdep.NotificacaoDevolucaoEmprestimoAtrasoProlongado, Guid.NewGuid(), ExchangeSmeWorkers.CDEP));
            return true;
        }
    }
}
