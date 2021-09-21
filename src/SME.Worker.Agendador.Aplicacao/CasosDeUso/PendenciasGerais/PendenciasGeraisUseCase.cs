using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasGerais
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
