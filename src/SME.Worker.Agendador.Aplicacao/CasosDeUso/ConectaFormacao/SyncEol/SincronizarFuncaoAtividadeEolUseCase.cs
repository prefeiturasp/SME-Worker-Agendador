using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Fila;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SyncEol
{
    public class SincronizarFuncaoAtividadeEolUseCase : AbstractUseCase, ISincronizarFuncaoAtividadeEolUseCase
    {
        public SincronizarFuncaoAtividadeEolUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(
                RotasConectaFormacao.SincronizaFuncaoAtividade, 
                Guid.NewGuid(),
                RotasConectaFormacao.Exchange));
            return true;
        }
    }
}
