using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.PendenciasGerais
{
    public class PendenciasGeraisUseCase : AbstractUseCase, IPendenciasGeraisUseCase
    {
        public PendenciasGeraisUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.PendenciasGerais, Guid.NewGuid()));
        }
    }
}
