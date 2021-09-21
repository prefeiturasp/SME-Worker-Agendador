using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.SerapEstudantes
{
    public class SyncSerapEstudantesProvasUseCase : ISyncSerapEstudantesProvasUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesProvasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SyncSerapEstudantesProvas, Guid.NewGuid()));
        }
    }
}
