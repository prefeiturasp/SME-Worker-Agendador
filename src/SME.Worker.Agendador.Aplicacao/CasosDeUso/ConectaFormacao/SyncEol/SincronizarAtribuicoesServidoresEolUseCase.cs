using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Fila;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SyncEol
{
    public class SincronizarAtribuicoesServidoresEolUseCase : AbstractUseCase, ISincronizarAtribuicoesServidoresEolUseCase
    {
        public SincronizarAtribuicoesServidoresEolUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasConectaFormacao.SincronizaAtribuicoesServidoresEol, Guid.NewGuid()));
            return true;
        }
    }
}
