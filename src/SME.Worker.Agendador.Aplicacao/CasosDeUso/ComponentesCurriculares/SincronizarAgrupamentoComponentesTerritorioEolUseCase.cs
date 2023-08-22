using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ComponentesCurriculares
{
    public class SincronizarAgrupamentoComponentesTerritorioEolUseCase : AbstractUseCase, ISincronismoAgrupamentoComponentesTerritorioEolUseCase
    {
        public SincronizarAgrupamentoComponentesTerritorioEolUseCase(IMediator mediator) : base(mediator)
        {

        }
        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitEol.SincronizarAgrupamentosComponentesTerritorioSaberEolSync, Guid.NewGuid()));
        }
    }
}
