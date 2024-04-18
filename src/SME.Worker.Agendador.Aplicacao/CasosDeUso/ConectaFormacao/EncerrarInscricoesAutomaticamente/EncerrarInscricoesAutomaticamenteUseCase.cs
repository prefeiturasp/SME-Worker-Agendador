using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Fila;

namespace SME.Worker.Agendador.Aplicacao
{
    public class EncerrarInscricoesAutomaticamenteUseCase : AbstractUseCase, IEncerrarInscricoesAutomaticamenteUseCase
    {
        public EncerrarInscricoesAutomaticamenteUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasConectaFormacao.EncerrarInscricaoAutomaticamente, Guid.NewGuid()));
            return true;
        }
    }
}