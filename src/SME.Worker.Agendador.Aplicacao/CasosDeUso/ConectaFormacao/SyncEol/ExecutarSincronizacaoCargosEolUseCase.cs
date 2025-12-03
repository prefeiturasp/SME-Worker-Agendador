using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Fila;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SyncEol
{
    public class ExecutarSincronizacaoCargosEolUseCase : AbstractUseCase, IExecutarSincronizacaoCargosEolUseCase
    {
        public ExecutarSincronizacaoCargosEolUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasConectaFormacao.SincronizaCargosEol, Guid.NewGuid()));
            return true;
        }
    }
}