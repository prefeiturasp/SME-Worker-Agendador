using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.AulasPrevistas
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
