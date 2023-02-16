using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasGerais.RemoverPendencias
{
    public class RemoverPendenciasNoFinalDoAnoLetivoUseCase : AbstractUseCase, IRemoverPendenciasNoFinalDoAnoLetivoUseCase
    {
        public RemoverPendenciasNoFinalDoAnoLetivoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaExecutarExclusaoPendenciasNoFinalDoAnoLetivoPorAno, Guid.NewGuid()));
        }
    }
}
