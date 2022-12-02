using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class IniciarProcessoFinalizarProvasAutomaticamenteUseCase : IIniciarProcessoFinalizarProvasAutomaticamenteUseCase
    {
        protected readonly IMediator mediator;
        public IniciarProcessoFinalizarProvasAutomaticamenteUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar()
        {
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerap.IniciarProcessoFinalizarProvasAutomaticamente, Guid.NewGuid()));
        }
    }
}
