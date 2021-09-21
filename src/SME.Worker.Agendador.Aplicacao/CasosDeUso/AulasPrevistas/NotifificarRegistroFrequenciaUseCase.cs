using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.AulasPrevistas
{
    public class ExecutaNotificacaoAulasPrevistasUseCase : AbstractUseCase, IExecutaNotificacaoAulasPrevistasUseCase
    {
        public ExecutaNotificacaoAulasPrevistasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaNotificacaoAulasPrevistasSync, Guid.NewGuid()));
        }
    }
}
